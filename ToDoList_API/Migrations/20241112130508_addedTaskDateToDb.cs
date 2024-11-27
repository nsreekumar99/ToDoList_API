using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList_API.Migrations
{
    /// <inheritdoc />
    public partial class addedTaskDateToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "TaskDate",
                table: "ToDoListM",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "ToDoListM",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "TaskDate" },
                values: new object[] { new DateOnly(2024, 11, 12), new DateOnly(2024, 12, 1) });

            migrationBuilder.UpdateData(
                table: "ToDoListM",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "TaskDate" },
                values: new object[] { new DateOnly(2024, 11, 12), new DateOnly(2024, 12, 2) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskDate",
                table: "ToDoListM");

            migrationBuilder.UpdateData(
                table: "ToDoListM",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2024, 10, 28));

            migrationBuilder.UpdateData(
                table: "ToDoListM",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2024, 10, 28));
        }
    }
}
