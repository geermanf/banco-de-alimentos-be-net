using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BancoDeAlimentos.Migrations
{
    public partial class IdEnProductDelivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDelivery",
                table: "ProductDelivery");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "ProductDelivery",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDelivery",
                table: "ProductDelivery",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDelivery_ProductId",
                table: "ProductDelivery",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDelivery",
                table: "ProductDelivery");

            migrationBuilder.DropIndex(
                name: "IX_ProductDelivery_ProductId",
                table: "ProductDelivery");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductDelivery");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDelivery",
                table: "ProductDelivery",
                columns: new[] { "ProductId", "DeliveryId" });
        }
    }
}
