# JobAlert
This app uses **Python** scripts to scrap job offers from **linkedin** and **pracuj.pl**, and store them in local database. New offers, which are posted since last execution are showed by **C#** Windows form


Ideally, you would set up Task Scheduler to execute **main.py** every few hours

![Window](Window.jpg?raw=true "Window")

**Technology**:
* Python enviroment
* Selenium
* Chromedriver
* sqlite3

**Set-up**:

Setting-up is done via **config.json** file. Parameters to enter:
* `search`:
    * `jobtitle` - what to look for
    * `location` - what location to look in
* `limit` - limit of offers scrapped per search on site
* `daysconsidered` - days back to consider offer by its posting date
* `chromedriver` - chromedriver path
* `linkuser` - Linkedin username
* `linkpassword` - Linkedin password
* `headless` - 1 - do not show chrome, 0 - show chrome 
* `timeout` - timeout value in seconds when loading a page
