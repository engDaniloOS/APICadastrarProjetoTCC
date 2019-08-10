using RelacaoTcc.Domain.Models.DTO;
using RelacaoTcc.Dominio.Models;
using RelacaoTcc.Infrastructure;
using RelacaoTcc.Repositorio.Interface;
using System;
using System.Linq;

namespace RelacaoTcc.Repositorio
{
    public class RelacaoRepository : IRelacaoRepository
    {
        #region campos
        private readonly AppContexto contexto;
        private readonly string alunoJaRegistradoInativo = "Aluno(a) já registrado em outro projeto, não encontrado ou inativo!";
        private readonly string professorInativo = "O professor não foi encontrado ou esta inativo!";
        private readonly string projetoJaAssociado = "Projeto já associado!";
        private readonly string projetoInativo = "O projeto não foi encontrado ou esta inativo!";
        #endregion campos

        #region construtor
        public RelacaoRepository(AppContexto contexto)
        {
            this.contexto = contexto;
        }
        #endregion construtor

        #region métodos auxiliares

        private void IsProjetoAssociado(int projetoId)
        {
            if (contexto.ProjetosAlunos.Where(q => q.ProjetoId == projetoId).ToList().Count != 0 &&
                    contexto.ProjetosProfessores.Where(q => q.ProjetoId == projetoId).ToList().Count != 0)
                throw new ArgumentException(projetoJaAssociado);
        }

        private void IsProjetoAtivo(int projetoId)
        {
            if (contexto.Projetos.Where(q => q.Id == projetoId && q.IsAtivo).ToList().Count == 0)
                throw new ArgumentException(projetoInativo);
        }

        private void IsAlunoAssociado(int alunoId)
        {
            if (contexto.ProjetosAlunos.Where(q => q.AlunoId == alunoId).ToList().Count != 0)
                throw new ArgumentException(alunoJaRegistradoInativo);
        }

        private void IsAlunoAtivo(int alunoId)
        {
            if (contexto.Alunos.Where(q => q.Id == alunoId && q.IsAtivo).ToList().Count == 0)
                throw new ArgumentException(alunoJaRegistradoInativo);
        }

        private void IsProfessorAtivo(int professorId)
        {
            if (contexto.Professores.Where(q => q.Id == professorId && q.IsAtivo).ToList().Count == 0)
                throw new ArgumentException(professorInativo);
        }

        private void ValidaDadosAoCriar(RelacaoPostModel model)
        {
            IsProjetoAssociado(model.ProjetoId);
            IsProjetoAtivo(model.ProjetoId);
            IsProfessorAtivo(model.ProfessorId);
            foreach (var alunoId in model.AlunosId)
            {
                IsAlunoAssociado(alunoId);
                IsAlunoAtivo(alunoId);
            }
        }

        #endregion métodos auxiliares

        public void Criar(RelacaoPostModel model)
        {
            ValidaDadosAoCriar(model);
                
            contexto.Add(new ProjetoProfessor() { ProjetoId = model.ProjetoId, ProfessorId = model.ProfessorId });

            foreach (var alunoId in model.AlunosId)
                contexto.Add(new ProjetoAluno() { ProjetoId = model.ProjetoId, AlunoId = alunoId });

            contexto.SaveChanges();
        }
    }
}
