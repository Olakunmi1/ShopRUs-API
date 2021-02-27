# ShopRUs-API
A Retail Api that provides Discounts to their customers base on different types, create customer, get List of Customers, create Discount, get specific discounts and the likes.
Below is the detail steps to get the Solution running on your branch 

Step1: Install the packages below 
  -- <Microsoft.EntityFrameworkCore.Relational" Version="5.0.3" />
  -- <"Microsoft.EntityFrameworkCore.SqlServer" Version="5.0.3" />
  -- <"Microsoft.EntityFrameworkCore.Tools" Version="5.0.3"> 
  -- database used is SQL Server (you can opt for something diff)
  --  <"Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version="3.1.12" /> 
  -- <Microsoft.EntityFrameworkCore.Design">
  
  -- Below are packages used for Logging 
  -- <"NLog.Web.AspNetCore" Version="4.9.1" />
  -- <"NLog.Config" Version="4.7.7" />
  
  -- Below are packges for Documentation (API Documentation)
  -- <"Swashbuckle.AspNetCore" Version="6.0.2" />
  -- <"Swashbuckle.AspNetCore.Filters" Version="6.0.1" />
  -- <"Swashbuckle.AspNetCore.SwaggerGen" Version="6.0.1" />
  -- <"Swashbuckle.AspNetCore.SwaggerUI" Version="6.0.1" />
  
  Step2: Database targeted is SQLServer but feel free to opt in for any database, 
  your connectin string still lives in appsettings.json, although i abstracted mine into Secret.json file
  which isnt published on github
  
  Step3: You can run initial Maigration with the command below
  Add-migartion InitialMigration
  
