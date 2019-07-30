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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Aluno>().HasKey(q => q.Id);
            //builder.Entity<Aluno>().Property(q => q.Id).HasColumnName("ID");
            //builder.Entity<Aluno>().Property(q => q.IsAtivo).HasColumnName("ATIVO");
            //builder.Entity<Aluno>().Property(q => q.Nome).HasColumnName("NOME").HasColumnType("varchar(255)").IsRequired();
            //builder.Entity<Aluno>().Property(q => q.Profissao).HasColumnName("PROFISSAO").HasColumnType("varchar(50)");
            //builder.Entity<Aluno>().Property(q => q.Registro).HasColumnName("REGISTRO").HasColumnType("varchar(20)").IsRequired();

            //builder.Entity<Professor>().HasKey(q => q.Id);
            //builder.Entity<Professor>().Property(q => q.Id).HasColumnName("ID");
            //builder.Entity<Professor>().Property(q => q.IsAtivo).HasColumnName("ATIVO");
            //builder.Entity<Professor>().Property(q => q.Nome).HasColumnName("NOME").HasColumnType("varchar(255)").IsRequired();
            //builder.Entity<Professor>().Property(q => q.Registro).HasColumnName("REGISTRO").HasColumnType("varchar(20)").IsRequired();

            //builder.Entity<Projeto>().HasKey(q => q.Id);
            //builder.Entity<Projeto>().Property(q => q.Id).HasColumnName("ID");
            //builder.Entity<Projeto>().Property(q => q.IsAtivo).HasColumnName("ATIVO");
            //builder.Entity<Projeto>().Property(q => q.Nome).HasColumnName("NOME").HasColumnType("varchar(255)").IsRequired();
            //builder.Entity<Projeto>().Property(q => q.Registro).HasColumnName("REGISTRO").HasColumnType("varchar(20)").IsRequired();
            //builder.Entity<Projeto>().Property(q => q.Descricao).HasColumnName("DESCRICAO").HasColumnType("varchar(255)");
            //builder.Entity<Projeto>().Property(q => q.DataIni).HasColumnName("DATA_INICIO");
            //builder.Entity<Projeto>().Property(q => q.DataFim).HasColumnName("DATA_FIM");

            //builder.Entity<ProjetoAluno>().HasKey(q => q.Id);
            //builder.Entity<ProjetoAluno>().Property(q => q.Id).HasColumnName("ID");
            //builder.Entity<ProjetoAluno>().Property(q => q.IsAtivo).HasColumnName("ATIVO");
            //builder.Entity<ProjetoAluno>().Property(q => q.AlunoId).HasColumnName("ALUNO_ID");
            //builder.Entity<ProjetoAluno>().Property(q => q.ProjetoId).HasColumnName("PROJETO_ID");

            //builder.Entity<ProjetoProfessor>().HasKey(q => q.Id);
            //builder.Entity<ProjetoProfessor>().Property(q => q.Id).HasColumnName("ID");
            //builder.Entity<ProjetoProfessor>().Property(q => q.IsAtivo).HasColumnName("ATIVO");
            //builder.Entity<ProjetoProfessor>().Property(q => q.ProfessorId).HasColumnName("PROFESSOR_ID");
            //builder.Entity<ProjetoProfessor>().Property(q => q.ProjetoId).HasColumnName("PROJETO_ID");
        }
    }
}
