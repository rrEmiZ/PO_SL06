using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleAppCore.Migrations
{
    public partial class Dicounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Discounts",
                newName: "DicountProcent");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Discounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Discounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Discounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_BrandId",
                table: "Discounts",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_CategoryId",
                table: "Discounts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_ProductId",
                table: "Discounts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_brands_BrandId",
                table: "Discounts",
                column: "BrandId",
                principalSchema: "production",
                principalTable: "brands",
                principalColumn: "brand_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_categories_CategoryId",
                table: "Discounts",
                column: "CategoryId",
                principalSchema: "production",
                principalTable: "categories",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_products_ProductId",
                table: "Discounts",
                column: "ProductId",
                principalSchema: "production",
                principalTable: "products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_brands_BrandId",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_categories_CategoryId",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_products_ProductId",
                table: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_BrandId",
                table: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_CategoryId",
                table: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_ProductId",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Discounts");

            migrationBuilder.RenameColumn(
                name: "DicountProcent",
                table: "Discounts",
                newName: "Value");
        }
    }
}
