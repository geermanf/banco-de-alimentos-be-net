using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Farmacity.FCDM.BackOffice.Migrations
{
    public partial class LoginMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "InternalUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "InternalUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsOrganization",
                table: "InternalUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "OrganizationInfoId",
                table: "InternalUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(nullable: true),
                    OrganizationName = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Children = table.Column<string>(nullable: true),
                    Adults = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    Reference = table.Column<string>(nullable: true),
                    ResponsableFirstName = table.Column<string>(nullable: true),
                    ResponsableLastName = table.Column<string>(nullable: true),
                    ResponsableEmail = table.Column<string>(nullable: true),
                    ResponsablePhone = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InternalUsers_OrganizationInfoId",
                table: "InternalUsers",
                column: "OrganizationInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_InternalUsers_Organizations_OrganizationInfoId",
                table: "InternalUsers",
                column: "OrganizationInfoId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InternalUsers_Organizations_OrganizationInfoId",
                table: "InternalUsers");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_InternalUsers_OrganizationInfoId",
                table: "InternalUsers");

            migrationBuilder.DropColumn(
                name: "IsOrganization",
                table: "InternalUsers");

            migrationBuilder.DropColumn(
                name: "OrganizationInfoId",
                table: "InternalUsers");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "InternalUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "InternalUsers",
                nullable: true);
        }
    }
}
