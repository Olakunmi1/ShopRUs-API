﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopRUs_API.ShopRu.DataAccess.DBContext;

namespace ShopRUs_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210302135913_Seeder")]
    partial class Seeder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShopRUs_API.ShopRu.DataAccess.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("typeOfCustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("typeOfCustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "20, Marina Lagos island. ",
                            created_at = new DateTime(2021, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            email = "Moss@gmail.com",
                            firstName = "John",
                            gender = "Male",
                            lastName = "Moss",
                            typeOfCustomerId = 1,
                            updated_at = new DateTime(2021, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Address = "24, Fakunle Street, Yaba Lagos. ",
                            created_at = new DateTime(2021, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            email = "Almond@gmail.com",
                            firstName = "Mark",
                            gender = "Male",
                            lastName = "Almond",
                            typeOfCustomerId = 2,
                            updated_at = new DateTime(2021, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Address = "10, Taiwo Ibrahim Street, Igando Lagos. ",
                            created_at = new DateTime(2018, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            email = "Balogun@gmail.com",
                            firstName = "Damilola",
                            gender = "Female",
                            lastName = "Balogun",
                            typeOfCustomerId = 3,
                            updated_at = new DateTime(2018, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Address = "30, Taiwo Ibrahim Street, Igando Lagos. ",
                            created_at = new DateTime(2018, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            email = "Agboola@gmail.com",
                            firstName = "Olakunmi",
                            gender = "Male",
                            lastName = "Agboola",
                            typeOfCustomerId = 3,
                            updated_at = new DateTime(2018, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Address = "45, Taiwo Ibrahim Street, Igando Lagos. ",
                            created_at = new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            email = "Aminat123@gmail.com",
                            firstName = "Aminat",
                            gender = "Female",
                            lastName = "Balogun",
                            typeOfCustomerId = 4,
                            updated_at = new DateTime(2018, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ShopRUs_API.ShopRu.DataAccess.Entities.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiscountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PercentageId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PercentageId");

                    b.ToTable("Discounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Currency = "USD($)",
                            DiscountType = "Affiliate",
                            PercentageId = 1,
                            Price = 0.1m
                        },
                        new
                        {
                            Id = 2,
                            Currency = "USD($)",
                            DiscountType = "Employee",
                            PercentageId = 2,
                            Price = 0.3m
                        },
                        new
                        {
                            Id = 3,
                            Currency = "USD($)",
                            DiscountType = "CustomerOverTwoYears",
                            PercentageId = 3,
                            Price = 0.05m
                        });
                });

            modelBuilder.Entity("ShopRUs_API.ShopRu.DataAccess.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DiscountedPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Percentage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Tax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalBill")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("typeOfCustomerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("typeOfCustomerId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("ShopRUs_API.ShopRu.DataAccess.Entities.Percentage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("percentage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("percentages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comment = "Customer gets 10% discount ",
                            Created_at = new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            percentage = 10
                        },
                        new
                        {
                            Id = 2,
                            Comment = "Customer gets 30% discount ",
                            Created_at = new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            percentage = 30
                        },
                        new
                        {
                            Id = 3,
                            Comment = "Customer for over 2 years, gets 5% discount ",
                            Created_at = new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            percentage = 5
                        });
                });

            modelBuilder.Entity("ShopRUs_API.ShopRu.DataAccess.Entities.TypeOfCustomer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("typeOfCustomers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comment = "Customer gets 10% discount as an affiliate of the store ",
                            Created_at = new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Affiliate"
                        },
                        new
                        {
                            Id = 2,
                            Comment = "Customer gets 30% discount as an employee of the store ",
                            Created_at = new DateTime(2020, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Employee"
                        },
                        new
                        {
                            Id = 3,
                            Comment = "If User has been a Customer for over 2 years, custormer gets 5% discount ",
                            Created_at = new DateTime(2021, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "CustomerOverTwoYears"
                        },
                        new
                        {
                            Id = 4,
                            Comment = "An Ordinary type of Customer gets $5 discount only on every $100 bill ",
                            Created_at = new DateTime(2021, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Ordinary"
                        });
                });

            modelBuilder.Entity("ShopRUs_API.ShopRu.DataAccess.Entities.Customer", b =>
                {
                    b.HasOne("ShopRUs_API.ShopRu.DataAccess.Entities.TypeOfCustomer", "typeOfCustomer")
                        .WithMany()
                        .HasForeignKey("typeOfCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("typeOfCustomer");
                });

            modelBuilder.Entity("ShopRUs_API.ShopRu.DataAccess.Entities.Discount", b =>
                {
                    b.HasOne("ShopRUs_API.ShopRu.DataAccess.Entities.Percentage", "percentage")
                        .WithMany()
                        .HasForeignKey("PercentageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("percentage");
                });

            modelBuilder.Entity("ShopRUs_API.ShopRu.DataAccess.Entities.Invoice", b =>
                {
                    b.HasOne("ShopRUs_API.ShopRu.DataAccess.Entities.TypeOfCustomer", "typeOfCustomer")
                        .WithMany()
                        .HasForeignKey("typeOfCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("typeOfCustomer");
                });
#pragma warning restore 612, 618
        }
    }
}