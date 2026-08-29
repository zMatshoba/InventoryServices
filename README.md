Introduction
TODO: This folder has an ASP.NET Core Web API and a ASP.NET Core MVC Application.
-   All is developed in the .Net 8 standard.

Getting Started
-   You will need to add all the tokenized variables in both projects appsettings.json to the secrets.json file to ensure the application will start with no problem.
-   You will need to ensure that you set both the Web API and MVC project to be start up projects on the profile.
-   Note that the MVC project will only have one view for the Daily sales summary.
-   All other functionality will be on the Web API endpoints.

Technology Stack 
-   .NET 8
-   ASP.NET CORE Web API
-   ASP.NET CORE MVC
-   C#
-   Entity Framework Core
-   SQL Server
-   Serilog for Structured application logging
-   Bootstrap

Unit of work on the API
-   Products (Full CRUD including stock adjustment)
-   Orders (Endpoint to allow external ERP systems to create orders on our system. This also includes InventoryAdjustment table which silently tracks Initial,Increase,or Decrease in stock.)
-   Report (This gives us the daily sales summary report)