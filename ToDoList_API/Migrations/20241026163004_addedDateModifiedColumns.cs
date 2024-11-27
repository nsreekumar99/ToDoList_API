using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList_API.Migrations
{
    /// <inheritdoc />
    public partial class addedDateModifiedColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "CreatedDate",
                table: "ToDoListM",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "UpdatedDate",
                table: "ToDoListM",
                type: "date",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ToDoListM");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ToDoListM");
        }
    }
}
