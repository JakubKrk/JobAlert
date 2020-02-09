from misc import Offer, Search, Offerbase, Config
import misc
import linkedin, pracujpl
import csv
import subprocess
import os
import concurrent.futures

#Create new offers list
newoffers = []
newoffers_pracujpl = []
newoffers_linkedin = []


#Read config file
config = Config('config.json')

#Create separate threads for linkedin and pracuj.pl
with concurrent.futures.ThreadPoolExecutor() as executor:
    linkedin = executor.submit(linkedin.linkedin_search, config)
    pracuj = executor.submit(pracujpl.pracujpl_search, config)
    newoffers_linkedin = linkedin.result()
    newoffers_pracujpl = pracuj.result()

newoffers = newoffers_pracujpl + newoffers_linkedin

#Update log
db = Offerbase('offers.db')
for task in config.searches:
    db.update_log(Search(task['jobtitle'],task['location']))
db.close()

#Create temp csv file    
if len(newoffers) > 0:
    with open('temp.csv', mode='w',newline='') as temp:
        temp_write = csv.writer(temp, delimiter=';', quotechar='"', quoting=csv.QUOTE_MINIMAL)
        temp_write.writerow([len(newoffers),])
        for offer in newoffers:
            titlechanged = misc.remove_polish_letters(offer.title)
            companychanged = misc.remove_polish_letters(offer.company)
            locationchanged = misc.remove_polish_letters(offer.location)
            date_str = offer.date.strftime("%d %B")
            temp_write.writerow([titlechanged, companychanged, date_str, offer.site, locationchanged, offer.link, offer.searchtag])


    #Call Results form to present offers
    subprocess.call(["AlertWindow.exe"])

    #Remove temp file
    os.remove("temp.csv")
