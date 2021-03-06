﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RelacaoTcc.Infrastructure;

namespace RelacaoTcc.Migrations
{
    [DbContext(typeof(AppContexto))]
    [Migration("20190809194641_RelacaoProjetoProfessorAluno")]
    partial class RelacaoProjetoProfessorAluno
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RelacaoTcc.Dominio.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Celular");

                    b.Property<bool>("IsAtivo");

                    b.Property<string>("Nome");

                    b.Property<string>("Profissao");

                    b.Property<int?>("ProjetoAlunoId");

                    b.Property<string>("Registro");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoAlunoId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("RelacaoTcc.Dominio.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAtivo");

                    b.Property<string>("Nome");

                    b.Property<string>("Registro");

                    b.HasKey("Id");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("RelacaoTcc.Dominio.Models.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataFim");

                    b.Property<DateTime>("DataIni");

                    b.Property<string>("Descricao");

                    b.Property<bool>("IsAtivo");

                    b.Property<string>("Nome");

                    b.Property<string>("Registro");

                    b.HasKey("Id");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("RelacaoTcc.Dominio.Models.ProjetoAluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlunoId");

                    b.Property<int>("ProjetoId");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("ProjetosAlunos");
                });

            modelBuilder.Entity("RelacaoTcc.Dominio.Models.ProjetoProfessor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProfessorId");

                    b.Property<int>("ProjetoId");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.HasIndex("ProjetoId");

                    b.ToTable("ProjetosProfessores");
                });

            modelBuilder.Entity("RelacaoTcc.Dominio.Models.Aluno", b =>
                {
                    b.HasOne("RelacaoTcc.Dominio.Models.ProjetoAluno")
                        .WithMany("Alunos")
                        .HasForeignKey("ProjetoAlunoId");
                });

            modelBuilder.Entity("RelacaoTcc.Dominio.Models.ProjetoAluno", b =>
                {
                    b.HasOne("RelacaoTcc.Dominio.Models.Projeto", "Projeto")
                        .WithMany()
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RelacaoTcc.Dominio.Models.ProjetoProfessor", b =>
                {
                    b.HasOne("RelacaoTcc.Dominio.Models.Professor", "Professores")
                        .WithMany()
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RelacaoTcc.Dominio.Models.Projeto", "Projeto")
                        .WithMany()
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
