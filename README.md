# ASP.NET Core 3.1 Api URL Shortener
A basic implementation of an URL shortener web api using ASP.NET Core 3.1 with Entity Framework Core and Swagger.

Goal
I've started this little project in order to have a support during my approach of ASP.NET Core Api.

My idea was to implement a simple web api using the framework.

I've chosen to implement an URL shortener application with Swagger because swagger uı is very easy and usefull.

# Algorithm
So, how works an URL shortener?

Basicaly, we store the URL in database

When we have the short URL the process is:

Generate random alphanumeric word which max 6 digits.
Load the data from DB.
redirect to the original URL using an HTTP redirection.


# Usage
First, you have to type dotnet restore in order to retrieve the dependencies of the project.

The project is using SQLite as DB backend. The data file is named urls.db by default.

Open "UrlShortener.DAL" folder location.

In order to init the DB schema, you have to run the commands "dotnet ef migrations add mig_1" 

Then you have to run the commands "dotnet ef database update" 

Then, simply type dotnet run on your command prompt and then browse to http://localhost:5000.

Thanks to the ease of use of the swagger screen, you can shorten the url, make a custom url shortening or query your registered url.

If You use registered short url (shrt) after host address like "http://localhost:5000/shrt", You will access registered original address.

# Screenshot of the web application:

![This is an image](https://raw.githubusercontent.com/kazimagircan/UrlShortener/master/UrlShortener.API/Screenshot.png)

# Conclusion
After 6 hours, I brought this little application to life thanks to ASP.NET Core.
