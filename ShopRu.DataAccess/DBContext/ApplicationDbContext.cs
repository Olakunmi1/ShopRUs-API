using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopRUs_API.ShopRu.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRUs_API.ShopRu.DataAccess.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
           : base(options)
        {
        }

        //DbSets that connects to the database
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Percentage> percentages {get; set;}
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<TypeOfCustomer> typeOfCustomers { get; set; }

        //-- Uncomment the line below when you want to seed database 
        //Seeds database when migration is added, Use command below
        // Add-migration SeedDb

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<TypeOfCustomer>().HasData(

               //Type of customers within the store 
               new TypeOfCustomer()
               {
                   Id = 1,
                   Type = "Affiliate",
                   Comment = "Customer gets 10% discount as an affiliate of the store ",
                   Created_at = new DateTime(2020, 05, 11)
               },
               new TypeOfCustomer()
               {
                   Id = 2,
                   Type = "Employee",
                   Comment = "Customer gets 30% discount as an employee of the store ",
                   Created_at = new DateTime(2020, 10, 05)
               },
                new TypeOfCustomer()
               {
                   Id = 3,
                   Type = "CustomerOverTwoYears",
                   Comment = "If User has been a Customer for over 2 years, custormer gets 5% discount ",
                   Created_at = new DateTime(2021, 2, 11)
                   
               },
                new TypeOfCustomer()
               {
                   Id = 4,
                   Type = "Ordinary", 
                   Comment = "An Ordinary type of Customer gets $5 discount only on every $100 bill ",
                   Created_at = new DateTime(2021, 1, 11) 
               }
           );

            //Customers within the store 
            modelBuilder.Entity<Customer>().HasData(

                //Customers within the store 
                new Customer()
                {
                    Id = 1,
                    firstName = "John",
                    lastName = "Moss",
                    email = "Moss@gmail.com",
                    gender = "Male",
                    Address = "20, Marina Lagos island. ",
                    created_at = new DateTime(2021, 1, 11),
                    updated_at = new DateTime(2021, 1, 11),
                    typeOfCustomerId = 1
                },
                new Customer()
                {
                    Id = 2,
                    firstName = "Mark",
                    lastName = "Almond",
                    email = "Almond@gmail.com",
                    gender = "Male",
                    Address = "24, Fakunle Street, Yaba Lagos. ",
                    created_at = new DateTime(2021, 2, 19),
                    updated_at = new DateTime(2021, 2, 19),
                    typeOfCustomerId = 2
                },
                new Customer()
                {
                    Id = 3,
                    firstName = "Damilola",
                    lastName = "Balogun",
                    email = "Balogun@gmail.com",
                    gender = "Female",
                    Address = "10, Taiwo Ibrahim Street, Igando Lagos. ",
                    created_at = new DateTime(2018, 01, 19),
                    updated_at = new DateTime(2018, 01, 19),
                    typeOfCustomerId = 3 // Customer over 2 years
                },
                new Customer()
                {
                    Id = 4,
                    firstName = "Olakunmi",
                    lastName = "Agboola",
                    email = "Agboola@gmail.com",
                    gender = "Male",
                    Address = "30, Taiwo Ibrahim Street, Igando Lagos. ",
                    created_at = new DateTime(2018, 01, 19),  /// Customer over 2 years
                    updated_at = new DateTime(2018, 01, 19),
                    typeOfCustomerId = 3 // Customer over 2 years
                },
                new Customer()
                {
                    Id = 5,
                    firstName = "Aminat",
                    lastName = "Balogun",
                    email = "Aminat123@gmail.com",
                    gender = "Female",
                    Address = "45, Taiwo Ibrahim Street, Igando Lagos. ",
                    created_at = new DateTime(2021, 02, 28),
                    updated_at = new DateTime(2018, 02, 28),
                    typeOfCustomerId = 4 // ordinary customer
                }
            );

            //Percentages pre defined
            modelBuilder.Entity<Percentage>().HasData(

               //Type of customers within the store 
               new Percentage()
               {
                   Id = 1,
                   percentage = 10,
                   Comment = "Customer gets 10% discount ",
                   Created_at = new DateTime(2020, 05, 11)
               },
               new Percentage()
               {
                   Id = 2,
                   percentage = 30,
                   Comment = "Customer gets 30% discount ",
                   Created_at = new DateTime(2020, 05, 11)
               },
               new Percentage()
               {
                   Id = 3,
                   percentage = 5,
                   Comment = "Customer for over 2 years, gets 5% discount ",
                   Created_at = new DateTime(2020, 05, 11)
               }
            //     new Percentage()
            //    {
            //        Id = 4,
            //        percentage = 5,
            //        Comment = "For Customer for over 2 years, gets 5% discount ",
            //        Created_at = new DateTime(2020, 05, 11)
            //    }
           );

            //Discount types available withing the store

             modelBuilder.Entity<Discount>().HasData(

               //Types of discounts within the store 
               new Discount()
               {
                   Id = 1,
                   PercentageId = 1,
                   Price = 0.1m,
                   Currency = "USD($)",
                   DiscountType = "Affiliate"
               },
               new Discount()
               {
                   Id = 2,
                   PercentageId = 2,
                   Price = 0.3m,
                   Currency = "USD($)",
                   DiscountType = "Employee"
               },
                new Discount()
               {
                    Id = 3,
                    PercentageId = 3,
                    Price = 0.05m,
                    Currency = "USD($)",
                    DiscountType = "CustomerOverTwoYears"
               }
            //     new Discount()
            //    {
            //         Id = 4,
            //         Percentage = null,
            //         Price = 5m,
            //         Currency = "USD($)",
            //         DiscountType = "Ordinary"
            //    }
           );
        }
       // */
    }
    
}
