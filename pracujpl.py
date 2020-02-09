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

def init_chromedriver(config):
    chrome_options = Options()
    #Fatal mode - no errors printed:
    chrome_options.add_argument("--log-level=3")
    if config.headless == 1: chrome_options.add_argument("--headless")

    #Create webdriver
    driver = webdriver.Chrome(executable_path=config.chromedriver,options=chrome_options)
    driver.set_page_load_timeout(config.timeout)
    return driver


#Function to create timestamp from pracuj.pl scraped date
def pracujpl_createTimestamp(date):
        conversions = {"stycznia": "Jan", "lutego": "Feb", "marca": "Mar", 'kwietnia': 'Apr', 'maja': 'May', 'czerwca': 'Jun', 'lipca': 'Jul', 'sierpnia': 'Aug', 'września': 'Sep', 'października': 'Oct','listopada': 'Nov','grudnia': 'Dec'}
        date = date.replace("\n", "")
        date = date.replace('opublikowana: ', '')
        datewords = date.split(" ")
        monthconverted = conversions[datewords[1]]
        dateT = datetime.strptime(datewords[0] + " " + monthconverted + " " + datewords[2], '%d %b %Y')
        return dateT

#Function to scrap data from each offercontainer on pracuj.pl:
def pracujpl_offerscrap(offercontainer):

    #Load offer html to BeautifulSoup4:
    soup = BeautifulSoup(offercontainer.get_attribute('innerHTML'), 'html.parser')

    try:
        soup.find("div",{"class":'offer offer--promoted offer--normal'})
        dateT = datetime.now().replace(microsecond=0)
    except:
        date = soup.find("span", {"class": 'offer-actions__date'}).text
        ##Create timestamp from str
        dateT = pracujpl_createTimestamp(date)
        pass
    
        
    try:
        title = (soup.find("a",{"class": 'offer-details__title-link'})).text
        location = soup.find("li", {"class": 'offer-labels__item offer-labels__item--location'}).text
        link = "https://pracuj.pl" + (soup.find("a", {"class" : "offer__click-area"}).get('href'))
    except:
        #Offer from several locations:
        title = (soup.find("button",{"class": 'offer-details__title-link'})).text
        location = "Several"
        link = "Several"
    
    company = soup.find('a', {'class': 'offer-company__name'}).text

    #Clean data from unnecessary chars:
    title = title.replace("\n", "")
    company = company.replace("\n", "")
    link = link.replace("\n", "")
    location  = location.replace("\n", "")

    return dateT, title, company, link, location

#Function to search pracuj.pl for jobtitle in specified location
#Return list of Offers
@my_timer
def pracujpl_search(config):

    #Init chromedriver
    driver = init_chromedriver(config)

    db = Offerbase('offers.db')

    #Create results list
    newoffers = []

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

        try:
            driver.get('https://www.pracuj.pl/praca/' + intitle + ';kw/' + inlocation + ';wp/')
        except TimeoutException:
            break
   
        #Check if there are any offers:
        #Check number of offers
        #Calculate number of pages:
        try:
            count = driver.find_element_by_class_name('results-header__offer-count-text-number')
        except:
            done = True
            break

        num_offers = int(count.text)
        num_pages = (num_offers // 50) + 1
        done = False
        currentoffer = 1

        #Go through each page:
        for page in range(num_pages):

            #Open page
            try:
                driver.get('https://www.pracuj.pl/praca/' + intitle + '/' + inlocation + ';wp?pn=' + str(page+1))
            except TimeoutException:
                break

            #Sleep and scroll down
            time.sleep(0.2)
            driver.execute_script("window.scrollTo(0, 1080)")

            #get offers container:
            offers = driver.find_elements_by_class_name('results__list-container-item')

            #Go through each offer:
            for occurrence in offers:

                #Scrap data
                dateT, title, company, link, location = pracujpl_offerscrap(occurrence)

                #Check if offer is newer than last search (~day) and in limit
                if dateT >= borderdate and currentoffer <= config.limit:

                    offer = Offer(dateT,title,company,link,location,'pracuj.pl',task['jobtitle'])

                    #Try to add offer to database and add to newoffers if succeeded
                    if db.insert_offer(offer):
                        newoffers.append(offer)
                
                #Dont consider in newoffers - already in the database
                else:
                    #Stop searching (next offers are older - already seen or limit is reached)
                    done = True
                    break
                

                currentoffer = currentoffer + 1
                
            if done: break

    #Return list with results:
    db.close()
    driver.close()
    return newoffers



