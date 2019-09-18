using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Entity.Migrations
{
    public partial class SeedData12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDateTime", "FirstName", "Nickname", "Password", "SecondName", "UpdateDateTime" },
                values: new object[] { 1L, new DateTime(2019, 9, 18, 11, 42, 35, 262, DateTimeKind.Local).AddTicks(2086), "test", "Standard 1", "111", "test1", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDateTime", "FirstName", "Nickname", "Password", "SecondName", "UpdateDateTime" },
                values: new object[] { -1L, new DateTime(2019, 9, 18, 11, 32, 44, 718, DateTimeKind.Local).AddTicks(4779), "test", "Standard 1", "111", "test1", null });
        }
    }
}
