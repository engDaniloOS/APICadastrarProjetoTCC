using Microsoft.EntityFrameworkCore;
using RelacaoTcc.Dominio.Models;

namespace RelacaoTcc.Infrastructure
{
    public class AppContexto : DbContext
    {
        public AppContexto(DbContextOptions options): base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<ProjetoProfessor> ProjetosProfessores { get; set; }
        public DbSet<ProjetoAluno> ProjetosAlunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
