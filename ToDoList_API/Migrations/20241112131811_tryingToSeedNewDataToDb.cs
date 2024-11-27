using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoList_API.Migrations
{
    /// <inheritdoc />
    public partial class tryingToSeedNewDataToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoListM",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ToDoListM",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "ToDoListM",
                columns: new[] { "Id", "CreatedDate", "Name", "TaskDate", "UpdatedDate", "isChecked" },
                values: new object[,]
                {
                    { 11, new DateOnly(2024, 11, 12), "Test New", new DateOnly(2024, 12, 1), null, true },
                    { 12, new DateOnly(2024, 11, 12), "Test New 2", new DateOnly(2024, 12, 2), null, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoListM",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ToDoListM",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.InsertData(
                table: "ToDoListM",
                columns: new[] { "Id", "CreatedDate", "Name", "TaskDate", "UpdatedDate", "isChecked" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 11, 12), "Test 1", new DateOnly(2024, 12, 1), null, false },
                    { 2, new DateOnly(2024, 11, 12), "Test 2", new DateOnly(2024, 12, 2), null, true }
                });
        }
    }
}
