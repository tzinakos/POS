using Microsoft.EntityFrameworkCore.Migrations;

namespace POS_Model.Migrations
{
    public partial class Fix_Product_AllergenRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allergens_Products_ProductID",
                table: "Allergens");

            migrationBuilder.DropIndex(
                name: "IX_Allergens_ProductID",
                table: "Allergens");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Allergens");

            migrationBuilder.AddColumn<int>(
                name: "AllergenID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_AllergenID",
                table: "Products",
                column: "AllergenID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Allergens_AllergenID",
                table: "Products",
                column: "AllergenID",
                principalTable: "Allergens",
                principalColumn: "AllergenID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Allergens_AllergenID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_AllergenID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AllergenID",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Allergens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Allergens_ProductID",
                table: "Allergens",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Allergens_Products_ProductID",
                table: "Allergens",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
