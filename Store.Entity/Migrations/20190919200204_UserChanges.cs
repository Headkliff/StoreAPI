using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Entity.Migrations
{
    public partial class UserChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDateTime", "Password" },
                values: new object[] { new DateTime(2019, 9, 19, 23, 2, 4, 271, DateTimeKind.Local).AddTicks(8156), "123456789" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDateTime", "Password" },
                values: new object[] { new DateTime(2019, 9, 19, 22, 36, 37, 31, DateTimeKind.Local).AddTicks(9102), "111" });
        }
    }
}
