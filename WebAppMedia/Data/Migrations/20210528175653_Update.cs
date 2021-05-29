using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppMedia.Data.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Alunos_AlunoId",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_AlunoId",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Notas");

            migrationBuilder.AddColumn<Guid>(
                name: "NotaId",
                table: "Alunos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_NotaId",
                table: "Alunos",
                column: "NotaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Notas_NotaId",
                table: "Alunos",
                column: "NotaId",
                principalTable: "Notas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Notas_NotaId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_NotaId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "NotaId",
                table: "Alunos");

            migrationBuilder.AddColumn<Guid>(
                name: "AlunoId",
                table: "Notas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notas_AlunoId",
                table: "Notas",
                column: "AlunoId");

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
