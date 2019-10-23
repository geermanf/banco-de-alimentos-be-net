using Microsoft.EntityFrameworkCore.Migrations;

namespace BancoDeAlimentos.Migrations
{
    public partial class Organization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Organizations",
                newName: "OrganizationPhone");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Organizations",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrganizationPhone",
                table: "Organizations",
                newName: "Phone");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Organizations",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
