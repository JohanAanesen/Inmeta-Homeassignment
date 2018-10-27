Exercise 1 � Service API
===
* Write an API (Rest service) that satisfies the user stories and does the business logic. In exercise 2, you will create a web application that will use the API.
* Requirements: C# / .Net core - Web API. Entity Framework as the database layer.

Todo:
---
- [ ] /GET - return all orders
- [ ] /GET/{id} - return order belonging to {id}
- [ ] /POST - create new order
- [ ] /PUT/{id} - Update order with {id}
- [ ] /DELETE/{id} - Delete order with {id}

Technical decisions:
---
- .NET is new to me so I first read some articles about web api in C#/.net core
- Entity Framework - Code-first or Database-first
    - Tried Database-first, because I like to design the database first then implement my own functionality for using the data. Generating the classes through EF didn't work for some reason
    - Tried Code-first, didn't work for some other reason
    - Combined the two and now it did work for some weird reason

- Because the application should be extendable, I deemed it natural to split the data into Customer and Order and create a one to many relationship.
- I could have different classes for the order type/service, but since all the orders contain the same information I keep them in the same class.
    - Then I wanted the service to be defined as an ENUM, but that seems to only be an MySQL thing :-1: , therefore I am keeping it as a string until further investigation.

Lessons learned:
---
- ConnectionString from SQL Server doesnt work, connect through Visual Studio and use the ConnectionString from it's properties instead.
- EntityFramework doesn't feel like working, therefore work around it