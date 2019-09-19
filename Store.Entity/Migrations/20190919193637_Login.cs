using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Entity.Migrations
{
    public partial class Login : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDateTime", "SecondName" },
                values: new object[] { new DateTime(2019, 9, 19, 22, 36, 37, 31, DateTimeKind.Local).AddTicks(9102), "test" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDateTime", "SecondName" },
                values: new object[] { new DateTime(2019, 9, 19, 10, 21, 18, 200, DateTimeKind.Local).AddTicks(9690), "test1" });
        }
    }
}
