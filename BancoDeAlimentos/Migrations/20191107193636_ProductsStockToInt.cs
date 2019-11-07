using Microsoft.EntityFrameworkCore.Migrations;

namespace BancoDeAlimentos.Migrations
{
    public partial class ProductsStockToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Stock",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Stock",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
