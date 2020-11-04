using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class decima_migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evaluation",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observation = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluation", x => x.id);
                    table.ForeignKey(
                        name: "FK_Evaluation_Proyectos_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Proyectos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Valoration",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observation = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Valoration = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valoration", x => x.id);
                    table.ForeignKey(
                        name: "FK_Valoration_Proyectos_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Proyectos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_ProjectId",
                table: "Evaluation",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Valoration_ProjectId",
                table: "Valoration",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluation");

            migrationBuilder.DropTable(
                name: "Valoration");
        }
    }
}
