using RelacaoTcc.Domain.Services;
using RelacaoTcc.Dominio.Models;
using RelacaoTcc.Dominio.Models.DTO;
using RelacaoTcc.Infrastructure.Repositorio;
using RelacaoTcc.Infrastructure.Repositorio.Interface;

namespace RelacaoTcc.Dominio.Services
{
    public class AlunoService : ComumService<Aluno, AlunoModel>, IService<Aluno, AlunoModel>
    {
        public AlunoService(IRepository<Aluno, AlunoModel> repository, IComumRepository<Aluno> comum) : base(repository, comum) { }
    }
}

