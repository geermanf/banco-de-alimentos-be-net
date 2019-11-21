using Microsoft.EntityFrameworkCore.Migrations;

namespace BancoDeAlimentos.Migrations
{
    public partial class deliverySecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Deliverys_DeliveryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DeliveryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductDelivery",
                columns: table => new
                {
                    ProductId = table.Column<long>(nullable: false),
                    DeliveryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDelivery", x => new { x.ProductId, x.DeliveryId });
                    table.ForeignKey(
                        name: "FK_ProductDelivery_Deliverys_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Deliverys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDelivery_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDelivery_DeliveryId",
                table: "ProductDelivery",
                column: "DeliveryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDelivery");

            migrationBuilder.AddColumn<long>(
                name: "DeliveryId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_DeliveryId",
                table: "Products",
                column: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Deliverys_DeliveryId",
                table: "Products",
                column: "DeliveryId",
                principalTable: "Deliverys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
