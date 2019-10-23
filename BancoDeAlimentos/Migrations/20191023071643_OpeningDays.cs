using Microsoft.EntityFrameworkCore.Migrations;

namespace BancoDeAlimentos.Migrations
{
    public partial class OpeningDays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OpeningDays",
                table: "Organizations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpeningDays",
                table: "Organizations");
        }
    }
}
