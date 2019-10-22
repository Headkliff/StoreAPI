using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Entity.Migrations
{
    public partial class CategoryRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_ItemCategoryId",
                table: "Items");

            migrationBuilder.AlterColumn<long>(
                name: "ItemCategoryId",
                table: "Items",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_ItemCategoryId",
                table: "Items",
                column: "ItemCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_ItemCategoryId",
                table: "Items");

            migrationBuilder.AlterColumn<long>(
                name: "ItemCategoryId",
                table: "Items",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_ItemCategoryId",
                table: "Items",
                column: "ItemCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
