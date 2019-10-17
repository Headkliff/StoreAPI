using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Entity.Migrations
{
    public partial class IntitItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Name", "Category", "Type", "CreateDateTime", "Cost" },
                values: new object[] { "Refractory Brick", "Construction Materials", "Brick", DateTime.UtcNow, 5f });
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
