using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Entity.Migrations
{
    public partial class ItemRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_ItemCategoryId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Types_ItemTypeId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "ItemTypeId",
                table: "Items",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "ItemCategoryId",
                table: "Items",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ItemTypeId",
                table: "Items",
                newName: "IX_Items_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ItemCategoryId",
                table: "Items",
                newName: "IX_Items_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Types_TypeId",
                table: "Items",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Types_TypeId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Items",
                newName: "ItemTypeId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Items",
                newName: "ItemCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_TypeId",
                table: "Items",
                newName: "IX_Items_ItemTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                newName: "IX_Items_ItemCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_ItemCategoryId",
                table: "Items",
                column: "ItemCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Types_ItemTypeId",
                table: "Items",
                column: "ItemTypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
