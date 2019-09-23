using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Store.Entity.Migrations
{
    public partial class InitUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Nickname", "Password", "FirstName", "SecondName", "CreateDateTime", "Email" },
                values: new object[] { "Test", "123456789", "tester", "testov", DateTime.UtcNow, "niki@mail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
