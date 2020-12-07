using Microsoft.EntityFrameworkCore.Migrations;

namespace POS_Model.Migrations
{
    public partial class Change_Relation_Between_Orders_And_Prod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.AddColumn<int>(
                name: "OrderProductID",
                table: "Products",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderProductID",
                table: "Orders",
                type: "int",
                nullable: true,
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrdersOrderID = table.Column<int>(type: "int", nullable: false),
                    ProductsProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrdersOrderID, x.ProductsProductID });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_OrdersOrderID",
                        column: x => x.OrdersOrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Products_ProductsProductID",
                        column: x => x.ProductsProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductsProductID",
                table: "OrderProduct",
                column: "ProductsProductID");
        }
    }
}
