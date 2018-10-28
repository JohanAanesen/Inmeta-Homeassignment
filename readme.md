Exercise 1 – Service API
===
* Write an API (Rest service) that satisfies the user stories and does the business logic. In exercise 2, you will create a web application that will use the API.
* Requirements: C# / .Net core - Web API. Entity Framework as the database layer.

Todo:
---
- [x] /GET - return all orders
- [x] /GET/{id} - return order with {id}
- [x] /POST - create new order
- [x] /PUT/{id} - Update order with {id}
- [x] /DELETE/{id} - Delete order with {id}
- [x] Put demo/server up on azure

Technical timeline:
---
- .NET is new to me so I first read some articles about web api in C#/.net core
- Entity Framework - Code-first or Database-first
    - Tried Database-first, because I like to design the database first then implement my own functionality for using the data. Generating the classes through EF didn't work for some reason
    - Tried Code-first, didn't work for some other reason
    - Combined the two and now it did work for some weird reason

- Because the application should be extendable, I deemed it natural to split the data into Customer and Order and create a one to many relationship between them.
- I could have different classes for the order type/service, but since all the orders contain the same information I keep them in the same class.
    - Then I wanted the service to be defined as an ENUM, but that seems to only be an MySQL thing :-1: , therefore I am keeping it as a string until further investigation.

- As of now I have 2 api endpoints, I want to merge these into one api for the application and the payload i should receive contains all info I need about both customer and order.
    - Think I can solve this by creating a class in which to accept the api data, and splitting it between the Customer and Order class.

- I think the above solution worked out pretty well. Will continue implementing the REST service this way :beers: 
- Spent some time trying to figure out updating the data, my app would spout on a part of the code where i tried to update customerId. I had forgotten this was a foreign key and thus nothing would happen :neutral_face: 
- I had another problem where my OrderDate didn't get set, fixed it by first going through my classes and seeing that they did in fact have the OrderDate attribute in there. Then I checked the DB for the same, and finally I added a function that actually sets it now. I wanted the DB to default set it to currenttime, but that didnt work out.
- Spent some time now getting the application/api up on Azure, it is available through https://inmeta20181027060410.azurewebsites.net/api
- I should use EnvVars for saving username/password for the connectionstring, I just don't know how in .Net yet.

Lessons learned:
---
- ConnectionString from SQL Server doesnt work, connect through Visual Studio and use the ConnectionString from it's properties instead.
- EntityFramework doesn't feel like working, therefore work around it
- It's hard to plan ahead when you don't know the frameworks or language
- Don't update Id's with foreign keys attached to them
- Getting to know C# / .Net Core and Entity Framework
- Deploying on Azure! :clap: :tada: 

---
Exercise 2 - Web
===
- Write a web-application that satisfies the user stories. The web application will use the API built in exercise 1.
- Requirements: React, Vue or Angular preferred (Pure HTML / CSS / JS will be accepted. You can add any other js library if needed). Preferably, use GULP/Webpack to run and pack the web application.
    - I went with Angular because I've been asked in 3 different interviews if I know "front end frameworks like Angular" (where my answer has always been No).

Todo:
---
- [x] Read up on Angular
- [x] Use Bootstrap
- [x] Dynamically create 'cards' for each order fetched from API
- [x] Create Order Form
- [x] Delete Button on each card
- [x] Edit button on each card
    - [x] Takes you to a edit card form
- [ ] ~~Search field?~~
- [ ] GULP/Webpack
- [x] Place Order
- [x] Find/See Orders
- [x] Edit Order
- [x] Delete Order

Technical Timeline:
---
- I followed some simple guides to setup the Angular project, I quickly ran into some problems related to GET'ing data from my API. First issue was that the API didn't have a Allow-Access-Origin something header, took a while but I solved it by updating my APi server to using CORS service. Now I believe the server will accept anything you throw at it. It probably isn't the best to leave it super open either.. :neutral_face: 
- Second big problem I had was trying to get the data from the response and onto an object/array. It was a bit weird since I could get the response and print it flawlessly, but when I assigned it to a variable and tried to print the variable I would only get 'Undefined' response. After a little research I realized the get function is somewhat asynchronous so when I tried to print out the variable, it hadn't been set yet... bummer! :disappointed: 
- Finally I can use some language/framework I know.. Bootstrap!
- I needed more than one function to get or send data to my api endpoint, so I found out that a service would be a better way to handle all http requests. This so instead of holding some http requests in every component, I would just request the service instead.
- Struggled a bit with the 'create new order'/POST parts as I wanted form validation instead of sending the server invalid data.. Solved it by reading the angular documentation.
- One of the user stories is "I want to find an order that I've previously placed for a customer"
    - I wanted to make a search bar so you could search for the customer and get all his orders listed, but I deemed it unnecessary to meet the criteria.
    - I am still filling that user story because you can indeed find the order, just not search or list for it. In a real setting I would contact my client and ask specifially how he would like it, but it is 17:30 on a sunday so I don't want to bother Moa.

