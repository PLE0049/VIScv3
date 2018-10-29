# VIS - Patterns example

This project contains partial implementation of some Design Patterns described in https://martinfowler.com/books/eaa.html 

<a href="http://disi.unal.edu.co/dacursci/sistemasycomputacion/docs/SWEBOK/Systems%20Engineering%20-%20EAA%20-%20Patterns%20of%20Enterprise%20Application%20Architecture%20-%20Addison%20Wesley.pdf">Book - trial version</a>

Project demonstrates the most suitable combinations of design patterns from data and domain layer. 

**Data Layer** - TableDataGateway, RowDataGateway, Active Record, Data Mapper

**Domain Layer** - Domain Model, Table Module, TransactionScript

**Universal Data Mapper** - https://github.com/MGSE97/CRMM/tree/master/ModelMapper

<h2>How To run</h2>

1. Clone repo
2. Use SQL scripts Create.sql and Insert.sql
3. Update sql connection strings in DBConnector.cs (DataLayer adn PresentationLayer)
3. Run the app

#eduardKubanda
#jakubPlesnik
