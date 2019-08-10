using RelacaoTcc.Domain.Models.DTO;
using RelacaoTcc.Repositorio.Interface;
using System;
using System.Collections.Generic;

namespace RelacaoTcc.Domain.Services
{
    public class RelacaoService : IRelacaoService
    {
        #region campos
        private readonly IRelacaoRepository repository;
        #endregion campos

        #region construtor
        public RelacaoService(IRelacaoRepository repository)
        {
            this.repository = repository;
        }
        #endregion construtor

        public RelacaoModel AlterarRelacao(RelacaoPostModel model, ref string mensagem)
        {
            throw new NotImplementedException();
        }

        public RelacaoModel BuscarProjeto(int id)
        {
            throw new NotImplementedException();
        }

        public RelacaoModel BuscarProjetoPorAluno(int alunoId)
        {
            throw new NotImplementedException();
        }

        public List<RelacaoModel> BuscarProjetosPorProfessor(int professorId)
        {
            throw new NotImplementedException();
        }

        public bool Criar(RelacaoPostModel model, ref string mensagem)
        {
            try
            {
                repository.Criar(model);
                return true;
            }
            catch (ArgumentException ex)
            {
                mensagem = ex.Message;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
