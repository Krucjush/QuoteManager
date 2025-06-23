using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuoteManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameDescriptionToProductName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "QuoteItems");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "QuoteItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "QuoteItems",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "ProductName",
                value: "Sample Product 1");

            migrationBuilder.UpdateData(
                table: "QuoteItems",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "ProductName",
                value: "Sample Product 2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "QuoteItems");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "QuoteItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "QuoteItems",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "Description",
                value: "Sample Product 1");

            migrationBuilder.UpdateData(
                table: "QuoteItems",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "Description",
                value: "Sample Product 2");
        }
    }
}
