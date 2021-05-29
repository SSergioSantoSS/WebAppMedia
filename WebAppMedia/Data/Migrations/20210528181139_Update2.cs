using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppMedia.Data.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TurmaId",
                table: "Notas",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Notas_TurmaId",
                table: "Notas",
                column: "TurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Turmas_TurmaId",
                table: "Notas",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Turmas_TurmaId",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_TurmaId",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "TurmaId",
                table: "Notas");
        }
    }
}
