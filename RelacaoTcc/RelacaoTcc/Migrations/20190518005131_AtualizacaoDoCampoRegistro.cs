using Microsoft.EntityFrameworkCore.Migrations;

namespace RelacaoTcc.Migrations
{
    public partial class AtualizacaoDoCampoRegistro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RA",
                table: "Alunos",
                newName: "Registro");

            migrationBuilder.AddColumn<string>(
                name: "Registro",
                table: "ProjetosProfessores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Registro",
                table: "ProjetosAlunos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Registro",
                table: "Projetos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Registro",
                table: "ProjetosProfessores");

            migrationBuilder.DropColumn(
                name: "Registro",
                table: "ProjetosAlunos");

            migrationBuilder.DropColumn(
                name: "Registro",
                table: "Projetos");

            migrationBuilder.RenameColumn(
                name: "Registro",
                table: "Alunos",
                newName: "RA");
        }
    }
}
