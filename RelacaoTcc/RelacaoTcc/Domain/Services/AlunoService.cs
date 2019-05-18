using RelacaoTcc.Domain.Services;
using RelacaoTcc.Dominio.Models;
using RelacaoTcc.Dominio.Models.DTO;
using RelacaoTcc.Infrastructure.Repositorio;
using RelacaoTcc.Infrastructure.Repositorio.Interface;
using System;

namespace RelacaoTcc.Dominio.Services
{
    public class AlunoService : ComumService<Aluno, AlunoModel>, IService<Aluno, AlunoModel>
    {
        #region Construtores
        public AlunoService(IRepository<Aluno, AlunoModel> repository, IComumRepository<Aluno> comum) : base(repository, comum)
        {
        }
        #endregion

        #region Metodos
        public Aluno Criar(AlunoModel model)
        {
            try
            {
                var aluno = new Aluno();

                if (!string.IsNullOrEmpty(model.Nome.Trim()) && !string.IsNullOrEmpty(model.RA.Trim()))
                {
                    if (repository.BuscarPorRegistro(model.RA).Id == 0 && comum.BuscarPor(model.Nome).Id == 0)
                        aluno = repository.Criar(model);

                    return aluno;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
}

