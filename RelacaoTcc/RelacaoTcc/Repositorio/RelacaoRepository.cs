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
        private readonly string alunoJaRegistradoInativo = "Aluno(a) já registrado em outro projeto!";
        private readonly string projetoJaAssociado = "Projeto já associado!";
        #endregion campos

        #region construtor
        public RelacaoRepository(AppContexto contexto)
        {
            this.contexto = contexto;
        }
        #endregion construtor

        #region métodos auxiliares

        public void VerificaProjetoAssociado(int projetoId)
        {
            if (contexto.ProjetosAlunos.Where(q => q.ProjetoId == projetoId).ToList().Count != 0 &&
                    contexto.ProjetosProfessores.Where(q => q.ProjetoId == projetoId).ToList().Count != 0)
                throw new ArgumentException(projetoJaAssociado);
        }

        public void VerificaAlunoAssociado(int alunoId)
        {
            if (contexto.ProjetosAlunos.Where(q => q.AlunoId == alunoId).ToList().Count != 0)
                throw new ArgumentException(alunoJaRegistradoInativo);
        }

        #endregion métodos auxiliares

        #region métodos principais
        public void Criar(RelacaoPostModel model)
        {
            contexto.Add(new ProjetoProfessor() { ProjetoId = model.ProjetoId, ProfessorId = model.ProfessorId });

            foreach (var alunoId in model.AlunosId)
                contexto.Add(new ProjetoAluno() { ProjetoId = model.ProjetoId, AlunoId = alunoId });

            contexto.SaveChanges();
        }
        #endregion métodos principais
    }
}
