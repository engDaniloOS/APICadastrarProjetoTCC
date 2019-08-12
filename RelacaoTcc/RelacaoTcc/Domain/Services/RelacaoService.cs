using RelacaoTcc.Domain.Models.DTO;
using RelacaoTcc.Dominio.Models;
using RelacaoTcc.Infrastructure.Repositorio;
using RelacaoTcc.Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RelacaoTcc.Domain.Services
{
    public class RelacaoService : IRelacaoService
    {
        #region campos
        private readonly IRelacaoRepository relacaoRepository;
        private readonly IComumRepository<Projeto> projetoRepository;
        private readonly IComumRepository<Professor> professorRepository;
        private readonly IComumRepository<Aluno> alunoRepository;

        private readonly string projetoInativo = "O projeto não foi encontrado ou esta inativo!";
        private readonly string professorInativo = "O professor não foi encontrado ou esta inativo!";
        private readonly string alunoJaRegistradoInativo = "Aluno(a) não encontrado ou inativo!";
        #endregion campos

        #region construtor
        public RelacaoService(IRelacaoRepository relacaoRepository,
                              IComumRepository<Projeto> projetoRepository,
                              IComumRepository<Professor> professorRepository,
                              IComumRepository<Aluno> alunoRepository)
        {
            this.relacaoRepository = relacaoRepository;
            this.projetoRepository = projetoRepository;
            this.professorRepository = professorRepository;
            this.alunoRepository = alunoRepository;
        }
        #endregion construtor

        #region métodos auxiliares
        private void ValidaElementos(RelacaoPostModel model)
        {
            relacaoRepository.VerificaProjetoAssociado(model.ProjetoId);

            if (projetoRepository.BuscarPor(model.ProjetoId).Id == 0)
                throw new ArgumentException(projetoInativo);

            if (professorRepository.BuscarPor(model.ProfessorId).Id == 0)
                throw new ArgumentException(professorInativo);

            foreach (var alunoId in model.AlunosId)
            {
                relacaoRepository.VerificaAlunoAssociado(alunoId);

                if (alunoRepository.BuscarPor(alunoId).Id == 0)
                    throw new ArgumentException(alunoJaRegistradoInativo);
            }
        }

        private List<int> RemoveDuplicidadeAlunos(List<int> lista)
            => lista.Distinct().ToList();
        #endregion métodos auxilares

        #region métodos principais
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
                model.AlunosId = RemoveDuplicidadeAlunos(model.AlunosId);
                
                ValidaElementos(model);

                relacaoRepository.Criar(model);
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
        #endregion métodos principais
    }
}
