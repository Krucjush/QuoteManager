using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuoteManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuoteItems",
                keyColumn: "Id",
                keyValue: new Guid("2849dbe6-086d-4b9a-9e22-244e9125fe74"));

            migrationBuilder.DeleteData(
                table: "QuoteItems",
                keyColumn: "Id",
                keyValue: new Guid("b7c8a542-c2b0-4570-a3be-0e885e2b07ae"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2492216f-004f-4999-a668-64cd9a1cd112"));

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: new Guid("cb3ed0bd-462f-4686-bb1e-fd5e2572a7d1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("78ccac43-a10e-44eb-916b-e86f0790667e"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Role" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "admin@example.com", "AdminPassword", "Admin" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "customer@example.com", "CustomerPassword", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "CreatedAt", "Title", "UserId" },
                values: new object[] { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample Quote for Customer", new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.InsertData(
                table: "QuoteItems",
                columns: new[] { "Id", "BasePrice", "Description", "ProductCode", "Quantity", "QuoteId", "ResellerPrice" },
                values: new object[,]
                {
                    { new Guid("44444444-4444-4444-4444-444444444444"), 100.00m, "Sample Product 1", "P001", 2, new Guid("33333333-3333-3333-3333-333333333333"), 95.00m },
                    { new Guid("55555555-5555-5555-5555-555555555555"), 150.00m, "Sample Product 2", "P002", 1, new Guid("33333333-3333-3333-3333-333333333333"), 140.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuoteItems",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "QuoteItems",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Role" },
                values: new object[,]
                {
                    { new Guid("2492216f-004f-4999-a668-64cd9a1cd112"), "admin@example.com", "AdminPassword", "Admin" },
                    { new Guid("78ccac43-a10e-44eb-916b-e86f0790667e"), "customer@example.com", "CustomerPassword", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "CreatedAt", "Title", "UserId" },
                values: new object[] { new Guid("cb3ed0bd-462f-4686-bb1e-fd5e2572a7d1"), new DateTime(2025, 6, 23, 18, 7, 42, 175, DateTimeKind.Utc).AddTicks(7984), "Sample Quote for Customer", new Guid("78ccac43-a10e-44eb-916b-e86f0790667e") });

            migrationBuilder.InsertData(
                table: "QuoteItems",
                columns: new[] { "Id", "BasePrice", "Description", "ProductCode", "Quantity", "QuoteId", "ResellerPrice" },
                values: new object[,]
                {
                    { new Guid("2849dbe6-086d-4b9a-9e22-244e9125fe74"), 150.00m, "Sample Product 2", "P002", 1, new Guid("cb3ed0bd-462f-4686-bb1e-fd5e2572a7d1"), 140.00m },
                    { new Guid("b7c8a542-c2b0-4570-a3be-0e885e2b07ae"), 100.00m, "Sample Product 1", "P001", 2, new Guid("cb3ed0bd-462f-4686-bb1e-fd5e2572a7d1"), 95.00m }
                });
        }
    }
}
