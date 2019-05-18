using RelacaoTcc.Domain.Models.DTO;
using RelacaoTcc.Dominio.Models;
using RelacaoTcc.Dominio.Services;
using RelacaoTcc.Infrastructure.Repositorio;
using RelacaoTcc.Infrastructure.Repositorio.Interface;
using System;

namespace RelacaoTcc.Domain.Services
{
    public class ProfessorService : ComumService<Professor, ProfessorModel>, IService<Professor, ProfessorModel>
    {
        #region Construtores
        public ProfessorService(IRepository<Professor, ProfessorModel> repository, IComumRepository<Professor> comum) : base(repository, comum) 
        {
        }
        #endregion

        #region Metodos
        public Professor Criar(ProfessorModel model)
        {
            try
            {
                var professor = new Professor();

                if (!string.IsNullOrEmpty(model.Nome.Trim()) && !string.IsNullOrEmpty(model.Registro.Trim()))
                {
                    if (repository.BuscarPorRegistro(model.Registro).Id == 0 && comum.BuscarPor(model.Nome).Id == 0)
                        professor = repository.Criar(model);

                    return professor;
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
