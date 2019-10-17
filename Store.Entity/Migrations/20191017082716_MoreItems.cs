using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Entity.Migrations
{
    public partial class MoreItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Name", "Category", "Type", "CreateDateTime", "Cost" },
                values: new object[] { "Bar Startul boat Standart ST5010", "Expendable materials", "Abrasive", DateTime.UtcNow, 1f });
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Name", "Category", "Type", "CreateDateTime", "Cost" },
                values: new object[] { "Acrylic bath Banoperito 150 * 70 cm Aralia with legs", "Plumbing", "Bathrooms", DateTime.UtcNow, 50f });
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Name", "Category", "Type", "CreateDateTime", "Cost" },
                values: new object[] { "Concrete mixer ECO CM-127", "Construction Equipment", "Concrete mixers", DateTime.UtcNow, 100f });
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Name", "Category", "Type", "CreateDateTime", "Cost" },
                values: new object[] { "Mirror Bella 60-20, Alavann", "Furniture", "Furniture for home", DateTime.UtcNow, 135f });
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Name", "Category", "Type", "CreateDateTime", "Cost" },
                values: new object[] { "Decorative plaster stone Paris A02", "Tile", "Decorative rock", DateTime.UtcNow, 10f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
