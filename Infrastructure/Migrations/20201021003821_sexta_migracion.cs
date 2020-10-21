using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class sexta_migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Student_1Id",
                table: "Proyectos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Student_2Id",
                table: "Proyectos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_Student_1Id",
                table: "Proyectos",
                column: "Student_1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_Student_2Id",
                table: "Proyectos",
                column: "Student_2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Estudiantes_Student_1Id",
                table: "Proyectos",
                column: "Student_1Id",
                principalTable: "Estudiantes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Estudiantes_Student_2Id",
                table: "Proyectos",
                column: "Student_2Id",
                principalTable: "Estudiantes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Estudiantes_Student_1Id",
                table: "Proyectos");

            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Estudiantes_Student_2Id",
                table: "Proyectos");

            migrationBuilder.DropIndex(
                name: "IX_Proyectos_Student_1Id",
                table: "Proyectos");

            migrationBuilder.DropIndex(
                name: "IX_Proyectos_Student_2Id",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "Student_1Id",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "Student_2Id",
                table: "Proyectos");
        }
    }
}
