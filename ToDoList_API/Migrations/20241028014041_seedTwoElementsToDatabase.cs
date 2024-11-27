using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoList_API.Migrations
{
    /// <inheritdoc />
    public partial class seedTwoElementsToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ToDoListM",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate", "isChecked" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 10, 28), "Test 1", null, false },
                    { 2, new DateOnly(2024, 10, 28), "Test 2", null, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoListM",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ToDoListM",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
