using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopRUs_API.Migrations
{
    public partial class Seeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "percentages",
                columns: new[] { "Id", "Comment", "Created_at", "percentage" },
                values: new object[,]
                {
                    { 1, "Customer gets 10% discount ", new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 2, "Customer gets 30% discount ", new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 30 },
                    { 3, "Customer for over 2 years, gets 5% discount ", new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 }
                });

            migrationBuilder.InsertData(
                table: "typeOfCustomers",
                columns: new[] { "Id", "Comment", "Created_at", "Type" },
                values: new object[,]
                {
                    { 1, "Customer gets 10% discount as an affiliate of the store ", new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Affiliate" },
                    { 2, "Customer gets 30% discount as an employee of the store ", new DateTime(2020, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employee" },
                    { 3, "If User has been a Customer for over 2 years, custormer gets 5% discount ", new DateTime(2021, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "CustomerOverTwoYears" },
                    { 4, "An Ordinary type of Customer gets $5 discount only on every $100 bill ", new DateTime(2021, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ordinary" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "created_at", "email", "firstName", "gender", "lastName", "typeOfCustomerId", "updated_at" },
                values: new object[,]
                {
                    { 1, "20, Marina Lagos island. ", new DateTime(2021, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moss@gmail.com", "John", "Male", "Moss", 1, new DateTime(2021, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "24, Fakunle Street, Yaba Lagos. ", new DateTime(2021, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Almond@gmail.com", "Mark", "Male", "Almond", 2, new DateTime(2021, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "10, Taiwo Ibrahim Street, Igando Lagos. ", new DateTime(2018, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Balogun@gmail.com", "Damilola", "Female", "Balogun", 3, new DateTime(2018, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "30, Taiwo Ibrahim Street, Igando Lagos. ", new DateTime(2018, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agboola@gmail.com", "Olakunmi", "Male", "Agboola", 3, new DateTime(2018, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "45, Taiwo Ibrahim Street, Igando Lagos. ", new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aminat123@gmail.com", "Aminat", "Female", "Balogun", 4, new DateTime(2018, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "Currency", "DiscountType", "PercentageId", "Price" },
                values: new object[,]
                {
                    { 1, "USD($)", "Affiliate", 1, 0.1m },
                    { 2, "USD($)", "Employee", 2, 0.3m },
                    { 3, "USD($)", "CustomerOverTwoYears", 3, 0.05m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "percentages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "percentages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "percentages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "typeOfCustomers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "typeOfCustomers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "typeOfCustomers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "typeOfCustomers",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
