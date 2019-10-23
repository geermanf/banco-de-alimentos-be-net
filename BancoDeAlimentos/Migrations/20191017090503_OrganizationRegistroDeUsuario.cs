using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BancoDeAlimentos.Migrations
{
    public partial class OrganizationRegistroDeUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegisterDate",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "RegisterDate",
                table: "InternalUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "InternalUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterDate",
                table: "Organizations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "InternalUsers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterDate",
                table: "InternalUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
