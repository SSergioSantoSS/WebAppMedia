using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppMedia.Data.Migrations
{
    public partial class Update6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SituacaoFinal",
                table: "Alunos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SituacaoFinal",
                table: "Alunos");
        }
    }
}
