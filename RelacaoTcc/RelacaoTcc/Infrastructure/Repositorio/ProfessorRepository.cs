using RelacaoTcc.Domain.Models.DTO;
using RelacaoTcc.Dominio.Models;
using RelacaoTcc.Infrastructure.Repositorio.Interface;
using System.Linq;

namespace RelacaoTcc.Infrastructure.Repositorio
{
    public class ProfessorRepository : ComumRepository<Professor>, IRepository<Professor, ProfessorModel>
    {
        public ProfessorRepository(AppContexto contexto) : base(contexto)
        {
        }

        public Professor Criar(ProfessorModel model)
        {
            Professor professor = new Professor()
            {
                IsAtivo = true,
                Nome = model.Nome,
                Registro = model.Registro,
            };

            contexto.Add(professor);
            contexto.SaveChanges();

            return professor;
        }

        public Professor Atualizar(ProfessorModel professor)
        {
            var resultado = contexto.Professores.Where(q => (q.Id == professor.Id) && q.IsAtivo).FirstOrDefault();
            //contexto.Update(resultado);
            //contexto.SaveChanges();
            return resultado;
        }
    }
}
