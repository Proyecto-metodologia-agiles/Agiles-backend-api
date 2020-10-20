using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class quinta_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advisorys",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProyectId = table.Column<int>(nullable: true),
                    ThematicAdvisorId = table.Column<int>(nullable: true),
                    MetodologicAdvisorId = table.Column<int>(nullable: true),
                    AssignedHours = table.Column<int>(nullable: false),
                    semester = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advisorys", x => x.id);
                    table.ForeignKey(
                        name: "FK_Advisorys_Asesors_MetodologicAdvisorId",
                        column: x => x.MetodologicAdvisorId,
                        principalTable: "Asesors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Advisorys_Proyectos_ProyectId",
                        column: x => x.ProyectId,
                        principalTable: "Proyectos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Advisorys_Asesors_ThematicAdvisorId",
                        column: x => x.ThematicAdvisorId,
                        principalTable: "Asesors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advisorys_MetodologicAdvisorId",
                table: "Advisorys",
                column: "MetodologicAdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Advisorys_ProyectId",
                table: "Advisorys",
                column: "ProyectId");

            migrationBuilder.CreateIndex(
                name: "IX_Advisorys_ThematicAdvisorId",
                table: "Advisorys",
                column: "ThematicAdvisorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advisorys");
        }
    }
}
