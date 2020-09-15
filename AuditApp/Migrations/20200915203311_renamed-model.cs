using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuditApp.Migrations
{
    public partial class renamedmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditEvents");

            migrationBuilder.CreateTable(
                name: "AuditEntities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Application = table.Column<string>(nullable: true),
                    Tenant = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    HappenedOn = table.Column<DateTime>(nullable: false),
                    EntityId = table.Column<string>(nullable: true),
                    EntityType = table.Column<string>(nullable: true),
                    Entity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditEntities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditEntities");

            migrationBuilder.CreateTable(
                name: "AuditEvents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Application = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HappenedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JSON = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditEvents", x => x.Id);
                });
        }
    }
}
