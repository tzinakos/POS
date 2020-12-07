using Microsoft.EntityFrameworkCore.Migrations;

namespace POS_Model.Migrations
{
    public partial class Change_Relation_Between_Orders_And_Pro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_orderProducts_OrderProductID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_orderProducts_OrderProductID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "orderProducts");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderProductID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderProductID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderProductID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderProductID",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderProductID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderProductID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "orderProducts",
                columns: table => new
                {
                    OrderProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderProducts", x => x.OrderProductID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderProductID",
                table: "Products",
                column: "OrderProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderProductID",
                table: "Orders",
                column: "OrderProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_orderProducts_OrderProductID",
                table: "Orders",
                column: "OrderProductID",
                principalTable: "orderProducts",
                principalColumn: "OrderProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_orderProducts_OrderProductID",
                table: "Products",
                column: "OrderProductID",
                principalTable: "orderProducts",
                principalColumn: "OrderProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
