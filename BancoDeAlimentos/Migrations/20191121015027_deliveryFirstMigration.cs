using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BancoDeAlimentos.Migrations
{
    public partial class deliveryFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DeliveryId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Deliverys",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: false),
                    EstimatedDate = table.Column<DateTime>(nullable: false),
                    EffectiveDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ExpiredProducts = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliverys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliverys_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_DeliveryId",
                table: "Products",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliverys_OrganizationId",
                table: "Deliverys",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Deliverys_DeliveryId",
                table: "Products",
                column: "DeliveryId",
                principalTable: "Deliverys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Deliverys_DeliveryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Deliverys");

            migrationBuilder.DropIndex(
                name: "IX_Products_DeliveryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "Products");
        }
    }
}
