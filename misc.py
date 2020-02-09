import sqlite3
from datetime import datetime, timedelta
import json

class my_timer(object):

    def __init__(self, function):
        self.function = function

    def __call__(self, *args, **kwargs):
        import time
        t1 = time.perf_counter()
        result = self.function(*args, **kwargs)
        print(f'{self.function.__name__} executed in {time.perf_counter() - t1} seconds')
        return result

def remove_polish_letters(string):
    string = string.replace("ą", "a")
    string = string.replace("Ą", "A")
    string = string.replace("ć", "c")
    string = string.replace("Ć", "C")
    string = string.replace("ę", "e")
    string = string.replace("Ę", "E")
    string = string.replace("ł", "l")
    string = string.replace("Ł", "L")
    string = string.replace("ń", "n")
    string = string.replace("Ń", "N")
    string = string.replace("ó", "o")
    string = string.replace("Ó", "O")
    string = string.replace("ś", "s")
    string = string.replace("Ś", "S")
    string = string.replace("ź", "z")
    string = string.replace("Ź", "Z")
    string = string.replace("ż", "z")
    string = string.replace("Ż", "Z")
    return string


class Config:

    def __init__(self,path):

        #Read config file
        json_file = open(path)
        config_input = json.load(json_file)
        json_file.close()

        self.searches = config_input['search']
        self.limit = config_input['limit']
        self.days = config_input['daysconsidered']
        self.chromedriver = config_input['chromedriver']
        self.linkuser = config_input['linkuser']
        self.linkpassword = config_input['linkpassword']
        self.headless = config_input['headless']
        self.timeout = config_input['timeout']

    #Read config file
    @property
    def borderdate(self):

        return datetime.now().replace(hour=0,minute=0,second=0,microsecond=0) - timedelta(self.days)
        
#Offer class consisting of datetime of posting, title, company name, link to offer, location and site where it was posted
#Will be stored in database offers table
class Offer:

    def __init__(self,date,title,company,link,location,site,searchtag=None):

        self.date = date
        self.title = title
        self.company = company
        self.link = link
        self.location = location
        self.site = site
        self.searchtag = searchtag

    def __str__(self):
        return "{} at {}, from {}".format(self.title, self.company, self.date)


    def __repr__(self):
        return "Offer({},{},{},{},{},{},{})".format(self.date, self.title, self.company, self.link, self.location, self.site, self.searchtag)


#Search class consisting of title, location and datetime of execution
#Will be stored in database log table
class Search:

    #By default date is setted to moment of instance creation
    def __init__(self,title,location,date=None):
        self.date = date or datetime.now().replace(microsecond=0)
        self.title = title
        self.location = location

    def __repr__(self):
        return 'Search({},{},{})'.format(self.date, self.title, self.location)

    def __str__(self):
        return "Search from {} on {} in {}".format(self.date, self.title, self.location)



#Offerbase class - layer of communication with database
#Consists of offers table storing Offer class instances
#and log table storing Search class instances
class Offerbase:

    def __init__(self,path):

        self.path = path
        self.conn = sqlite3.connect(path)
        self.c = self.conn.cursor()


        #Try to create offers and log tables if not existing
        with self.conn:
            try:
                self.c.execute("""CREATE TABLE offers (
                        date integer,
                        title text,
                        company text,
                        location text,
                        link text PRIMARY KEY,
                        site text,
                        searchtag text
                        )""")
            except:
                pass
            try:
                self.c.execute("""CREATE TABLE log (
                        date integer,
                        title text,
                        location text
                        )""")
            except:
                pass
            

    #Current number of Offers in database       
    @property
    def offers_size(self):
        self.c.execute("""
            SELECT COUNT(link)
            FROM offers
            """)
        size = self.c.fetchone()[0]
        return size


    #Current number of Searches in database    
    @property
    def log_size(self):

        self.c.execute("""
            SELECT COUNT(date)
            FROM log
            """)
        size = self.c.fetchone()[0]
        return size


    def __str__(self):
        return '{} Database containing {} offers and {} search logs'.format(self.path, self.offers_size, self.log_size)


    #Returns Search instance of most recent search in the log
    #Return None if there isnt any
    @property
    def last_search(self):

        with self.conn:
            try:
            
                self.c.execute("""SELECT *
                        FROM log
                        ORDER BY date DESC
                        LIMIT 1
                        """)
                
                lastsearch = self.c.fetchone()
                return Search(lastsearch[1],lastsearch[2],datetime.fromtimestamp(lastsearch[0]))
            except:
                return None
        
    #Inserts Offer instance to offers table
    #Returns True if successfully and False if not
    def insert_offer(self,offer):

        datestamp = int(datetime.timestamp(offer.date))

        with self.conn:
            try:
                self.c.execute("INSERT INTO offers VALUES (:date, :title, :company, :location, :link, :site, :searchtag)", {'date': datestamp, 'title': offer.title, 'company': offer.company, 'location':offer.location, 'link': offer.link, 'site': offer.site, 'searchtag':offer.searchtag})
                return True
            except:
                return False

    #Inserts Search instance to log table
    #Returns True if successfully and False if not
    def update_log(self, search):

        datestamp = int(datetime.timestamp(search.date))

        with self.conn:
            try:
                self.c.execute("INSERT INTO log VALUES (:date, :title, :location)", {'date': datestamp, 'title': search.title, 'location': search.location})
                return True
            except:
                return False

    #Get last Search instance with specified title and location from database
    #Returns None if there isnt any
    def get_last_search_by_values(self, title, location):

        with self.conn:

            self.c.execute("SELECT * FROM log WHERE title=:title AND location=:location ORDER BY date desc LIMIT 1", {'title': title, 'location': location})

            data = self.c.fetchone()
            
            if data is None:
                return None
            else:
                return Search(data[1],data[2],datetime.fromtimestamp(data[0]))


    #Returns Offer instances for specified company name
    #Returns None if there isn't any
    def get_offers_by_company(self,company):

        offers = []

        with self.conn:

            self.c.execute("SELECT * FROM offers WHERE company=:company", {'company': company})
            data = self.c.fetchall()
            
            if data is None:
                return None
            else:
                for record in data:
                    offers.append(Offer(datetime.fromtimestamp(record[0]),record[1],record[2],record[3],record[4],record[5], record[6]))

        return offers


    #Close connection
    def close(self):
        self.conn.close()
    
    #Removes Offer instance from database according to link
    #Returns True if successfully and False if not
    def remove_offer(self,offer):
        with self.conn:
            try:
                self.c.execute("DELETE from offers WHERE link = :link", {'link': offer.link})
                return True
            except:
                return False