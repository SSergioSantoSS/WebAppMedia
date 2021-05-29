using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppMedia.Data.Migrations
{
    public partial class Update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Alunos_AlunoId",
                table: "Notas");

            migrationBuilder.AlterColumn<Guid>(
                name: "AlunoId",
                table: "Notas",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Alunos_AlunoId",
                table: "Notas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Alunos_AlunoId",
                table: "Notas");

            migrationBuilder.AlterColumn<Guid>(
                name: "AlunoId",
                table: "Notas",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Alunos_AlunoId",
                table: "Notas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
