using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class undecima_migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluation_Proyectos_ProjectId",
                table: "Evaluation");

            migrationBuilder.DropForeignKey(
                name: "FK_Valoration_Proyectos_ProjectId",
                table: "Valoration");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Valoration",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Evaluation",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluation_Proyectos_ProjectId",
                table: "Evaluation",
                column: "ProjectId",
                principalTable: "Proyectos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Valoration_Proyectos_ProjectId",
                table: "Valoration",
                column: "ProjectId",
                principalTable: "Proyectos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluation_Proyectos_ProjectId",
                table: "Evaluation");

            migrationBuilder.DropForeignKey(
                name: "FK_Valoration_Proyectos_ProjectId",
                table: "Valoration");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Valoration",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Evaluation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluation_Proyectos_ProjectId",
                table: "Evaluation",
                column: "ProjectId",
                principalTable: "Proyectos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Valoration_Proyectos_ProjectId",
                table: "Valoration",
                column: "ProjectId",
                principalTable: "Proyectos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
