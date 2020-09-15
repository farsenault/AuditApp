using Microsoft.EntityFrameworkCore.Migrations;

namespace AuditApp.Migrations
{
    public partial class somechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExternalId",
                table: "AuditEvents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExternalType",
                table: "AuditEvents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "AuditEvents");

            migrationBuilder.DropColumn(
                name: "ExternalType",
                table: "AuditEvents");
        }
    }
}
