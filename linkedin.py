from selenium import webdriver
from selenium.webdriver.chrome.options import Options
from selenium.common.exceptions import NoSuchElementException
from selenium.common.exceptions import TimeoutException
from selenium.webdriver.common.keys import Keys

from bs4 import BeautifulSoup

import urllib.parse

from datetime import datetime
import time

from misc import Offer, Search, Offerbase, Config, my_timer

#Function to set up chromedriver:
def init_chromedriver(config):
    chrome_options = Options()
    #Fatal mode - no errors printed:
    chrome_options.add_argument("--log-level=3")
    if config.headless == 1: chrome_options.add_argument("--headless")

    #Create webdriver
    driver = webdriver.Chrome(executable_path=config.chromedriver,options=chrome_options)
    driver.set_page_load_timeout(config.timeout)
    return driver


#Function to scrap data from each offercontainer on linkedin:
def linkedin_offerscrap(offerHTML):
    #Load offer html to BeautifulSoup4:
    soup = BeautifulSoup(offerHTML, 'xml')
    #Scrap title, date, company name, location and link:
    try:
        title = (soup.find("a",{"class":'job-card-search__link-wrapper js-focusable disabled ember-view'})).text
    except:
        pass
    try:
        title = (soup.find("a",{"class":'job-card-search__link-wrapper js-focusable'})).text
    except:
        pass

    try:
        company = soup.find("a",{"class":'job-card-search__company-name-link t-normal ember-view'}).text
    except:
        company = soup.find("a",{"class":'job-card-search__company-name-link t-normal loading ember-view'}).text

    try:
        date = (soup.find("time",{"class":'job-card-search__time-badge job-card-search__time-badge--new'}))['datetime']
    except:
        date = (soup.find("time",{"class":'job-card-search__time-badge'}))['datetime']
        
    location = soup.find("span",{"class":'job-card-search__location artdeco-entity-lockup__caption ember-view'}).text
    link = (soup.find("a",{"class":'job-card-search__link-wrapper js-focusable disabled ember-view'}))['href']

    
    #Clean data from unnecessary chars:
    title = title.replace("\n", "")
    title = title.replace("  ", "")
    link = link.replace("\n", "")
    link = link.replace(" ", "")
    link = 'https://www.linkedin.com' + link
    company = company.replace("\n", "")
    company = company.replace("  ", "")
    date = date.replace("\n", "")
    date = date.replace(" ", "")
    location = location.replace("\n", "")
    location = location.replace(" ", "")

    ##Create timestamp from str
    dateT = datetime.strptime(date, "%Y-%m-%d")
    return dateT, title, company, link, location


#Function to search linkedin for jobtitle in specified location
#Return list of Offers
@my_timer
def linkedin_search(config):

    db = Offerbase('offers.db')

    driver = init_chromedriver(config)

    #Create results list:
    newoffers = []

    #Find sing in forms
    try:
        driver.get('https://www.linkedin.com/login')
    except TimeoutException:
        return newoffers

    
    try:
        user = driver.find_element_by_id('username')
        password = driver.find_element_by_id('password')
    except:
        db.close()
        driver.close()
        return newoffers

    
    #Insert account credentials
    user.send_keys(config.linkuser)
    password.send_keys(config.linkpassword)
    password.send_keys(Keys.ENTER)
    
    try:
        driver.find_element_by_id('captcha-internal')
        db.close()
        driver.close()
        return newoffers
    except:
        pass

    for task in config.searches:

        #Format input to url
        intitle = urllib.parse.quote(task['jobtitle'])
        inlocation = urllib.parse.quote(task['location'])
        
        #Get last search for this title and location from log
        #If there is no search in log, continue using border date from config file
        lastsearch = db.get_last_search_by_values(task['jobtitle'],task['location'])
        if lastsearch is not None:
            borderdate = lastsearch.date
        else:
            borderdate = config.borderdate

        done = False
        currentoffer = 1

        while True:

            #Open resutls page with &start= parameter on next offer to read
            try:
                driver.get('https://www.linkedin.com/jobs/search/?keywords=' + intitle + '&location=' + inlocation + '&sortBy=DD&start='+str(currentoffer-1))
            except TimeoutException:
                break
            
            #Sleep and scroll down
            driver.execute_script("window.scrollTo(0, 1080)")
            time.sleep(2)
            
            #Get page HTML and search it for offers containers in BS4
            pageHTML = driver.page_source
            soup = BeautifulSoup(pageHTML, 'html.parser')


            nooffers = soup.find_all('div', {'class': 'neptune-grid jobs-search-two-pane__no-results-banner'})
            if len(nooffers) > 0:
                print("Brak ofert")
                break

            offers = soup.find_all('li', {'class': 'occludable-update artdeco-list__item--offset-4 artdeco-list__item p0 ember-view'})
            
            #For each offer
            for occurrence in offers:
                #Scrap data
                dateT, title, company, link, location = linkedin_offerscrap(str(occurrence))
               
                #Check if offer is older than last search (~day)
                if dateT >= borderdate and currentoffer <= config.limit:
                    offer = Offer(dateT,title,company,link,location,'linkedin.com',task['jobtitle'])

                    #Try to add offer to database and add to newoffers if succeeded
                    if db.insert_offer(offer):
                        newoffers.append(offer)

                else:
                    #Stop searching (next offers are older - already seen or limit is reached)
                    done = True
                    break

                currentoffer = currentoffer + 1
            
            #Finish task if only 1 offer find
            if done or len(offers) == 1: break

    #Return list with results:
    db.close()
    driver.close()
    return newoffers