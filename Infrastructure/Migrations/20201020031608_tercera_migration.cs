using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Infrastructure.Migrations
{
    public partial class tercera_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Asesor_metodologicoId",
                table: "Proyectos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Asesor_tematicoId",
                table: "Proyectos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Corte",
                table: "Proyectos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Enfoque",
                table: "Proyectos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Proyectos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Linea",
                table: "Proyectos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Proyectos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url_Archivo",
                table: "Proyectos",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
