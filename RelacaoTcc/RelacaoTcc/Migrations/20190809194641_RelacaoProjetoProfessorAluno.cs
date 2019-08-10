using Microsoft.EntityFrameworkCore.Migrations;

namespace RelacaoTcc.Migrations
{
    public partial class RelacaoProjetoProfessorAluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAtivo",
                table: "ProjetosProfessores");

            migrationBuilder.DropColumn(
                name: "IsAtivo",
                table: "ProjetosAlunos");

            migrationBuilder.AddColumn<int>(
                name: "ProjetoAlunoId",
                table: "Alunos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjetosProfessores_ProfessorId",
                table: "ProjetosProfessores",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetosProfessores_ProjetoId",
                table: "ProjetosProfessores",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetosAlunos_ProjetoId",
                table: "ProjetosAlunos",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_ProjetoAlunoId",
                table: "Alunos",
                column: "ProjetoAlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_ProjetosAlunos_ProjetoAlunoId",
                table: "Alunos",
                column: "ProjetoAlunoId",
                principalTable: "ProjetosAlunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjetosAlunos_Projetos_ProjetoId",
                table: "ProjetosAlunos",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjetosProfessores_Professores_ProfessorId",
                table: "ProjetosProfessores",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjetosProfessores_Projetos_ProjetoId",
                table: "ProjetosProfessores",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_ProjetosAlunos_ProjetoAlunoId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjetosAlunos_Projetos_ProjetoId",
                table: "ProjetosAlunos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjetosProfessores_Professores_ProfessorId",
                table: "ProjetosProfessores");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjetosProfessores_Projetos_ProjetoId",
                table: "ProjetosProfessores");

            migrationBuilder.DropIndex(
                name: "IX_ProjetosProfessores_ProfessorId",
                table: "ProjetosProfessores");

            migrationBuilder.DropIndex(
                name: "IX_ProjetosProfessores_ProjetoId",
                table: "ProjetosProfessores");

            migrationBuilder.DropIndex(
                name: "IX_ProjetosAlunos_ProjetoId",
                table: "ProjetosAlunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_ProjetoAlunoId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "ProjetoAlunoId",
                table: "Alunos");

            migrationBuilder.AddColumn<bool>(
                name: "IsAtivo",
                table: "ProjetosProfessores",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAtivo",
                table: "ProjetosAlunos",
                nullable: false,
                defaultValue: false);
        }
    }
}
