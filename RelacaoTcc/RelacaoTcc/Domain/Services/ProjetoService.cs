using RelacaoTcc.Domain.Models.DTO;
using RelacaoTcc.Dominio.Models;
using RelacaoTcc.Dominio.Services;
using RelacaoTcc.Infrastructure.Repositorio;
using RelacaoTcc.Infrastructure.Repositorio.Interface;

namespace RelacaoTcc.Domain.Services
{
    public class ProjetoService : ComumService<Projeto, ProjetoModel>, IService<Projeto, ProjetoModel>
    {
        public ProjetoService(IRepository<Projeto, ProjetoModel> repository, IComumRepository<Projeto> comum) : base(repository, comum) { }
    }
}
