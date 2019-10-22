using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Entity.Migrations
{
    public partial class InitCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Name", "CreateDateTime" },
                values: new object[] { "Construction Materials", DateTime.UtcNow }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Name", "CreateDateTime" },
                values: new object[] { "Expendable materials", DateTime.UtcNow }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Name", "CreateDateTime" },
                values: new object[] { "Plumbing", DateTime.UtcNow }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Name", "CreateDateTime" },
                values: new object[] { "Construction Equipment", DateTime.UtcNow }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Name", "CreateDateTime" },
                values: new object[] { "Furniture", DateTime.UtcNow }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Name", "CreateDateTime" },
                values: new object[] { "Tile", DateTime.UtcNow }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
