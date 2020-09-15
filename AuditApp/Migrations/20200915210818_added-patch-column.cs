using Microsoft.EntityFrameworkCore.Migrations;

namespace AuditApp.Migrations
{
    public partial class addedpatchcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Patch",
                table: "AuditEntities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Patch",
                table: "AuditEntities");
        }
    }
}
