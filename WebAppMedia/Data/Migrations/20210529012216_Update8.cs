using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppMedia.Data.Migrations
{
    public partial class Update8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<float>(
                name: "Pf",
                table: "Notas",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Premio",
                table: "Notas",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SituacaoFinal",
                table: "Notas",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
