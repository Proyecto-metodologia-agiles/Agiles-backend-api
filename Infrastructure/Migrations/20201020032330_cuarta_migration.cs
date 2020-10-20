using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class cuarta_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Asesors_Asesor_metodologicoId",
                table: "Proyectos");

            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Asesors_Asesor_tematicoId",
                table: "Proyectos");

            migrationBuilder.DropIndex(
                name: "IX_Proyectos_Asesor_metodologicoId",
                table: "Proyectos");

            migrationBuilder.DropIndex(
                name: "IX_Proyectos_Asesor_tematicoId",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "Asesor_metodologicoId",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "Asesor_tematicoId",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "Corte",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "Enfoque",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "Linea",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "Url_Archivo",
                table: "Proyectos");

            migrationBuilder.AddColumn<int>(
                name: "Cut",
                table: "Proyectos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Proyectos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Focus",
                table: "Proyectos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Line",
                table: "Proyectos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Metodologic_AdvisorId",
                table: "Proyectos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Thematic_AdvisorId",
                table: "Proyectos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Proyectos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url_Archive",
                table: "Proyectos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_Metodologic_AdvisorId",
                table: "Proyectos",
                column: "Metodologic_AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_Thematic_AdvisorId",
                table: "Proyectos",
                column: "Thematic_AdvisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Asesors_Metodologic_AdvisorId",
                table: "Proyectos",
                column: "Metodologic_AdvisorId",
                principalTable: "Asesors",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Asesors_Thematic_AdvisorId",
                table: "Proyectos",
                column: "Thematic_AdvisorId",
                principalTable: "Asesors",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Asesors_Metodologic_AdvisorId",
                table: "Proyectos");

            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Asesors_Thematic_AdvisorId",
                table: "Proyectos");

            migrationBuilder.DropIndex(
                name: "IX_Proyectos_Metodologic_AdvisorId",
                table: "Proyectos");

            migrationBuilder.DropIndex(
                name: "IX_Proyectos_Thematic_AdvisorId",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "Cut",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "Focus",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "Line",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "Metodologic_AdvisorId",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "Thematic_AdvisorId",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "Url_Archive",
                table: "Proyectos");

            migrationBuilder.AddColumn<int>(
                name: "Asesor_metodologicoId",
                table: "Proyectos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Asesor_tematicoId",
                table: "Proyectos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Corte",
                table: "Proyectos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Enfoque",
                table: "Proyectos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Proyectos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Linea",
                table: "Proyectos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Proyectos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url_Archivo",
                table: "Proyectos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_Asesor_metodologicoId",
                table: "Proyectos",
                column: "Asesor_metodologicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_Asesor_tematicoId",
                table: "Proyectos",
                column: "Asesor_tematicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Asesors_Asesor_metodologicoId",
                table: "Proyectos",
                column: "Asesor_metodologicoId",
                principalTable: "Asesors",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Asesors_Asesor_tematicoId",
                table: "Proyectos",
                column: "Asesor_tematicoId",
                principalTable: "Asesors",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
