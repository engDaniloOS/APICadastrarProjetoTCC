using Microsoft.AspNetCore.Mvc;
using RelacaoTcc.Domain.Models.DTO;
using RelacaoTcc.Dominio.Models;
using RelacaoTcc.Dominio.Services;

namespace RelacaoTcc.Controllers
{
    [ApiController]
    [Route("api/projeto")]
    public class ProjetoController : ComumController<Projeto, ProjetoModel>
    {
        public ProjetoController(IService<Projeto, ProjetoModel> service) : base(service) { }
    }
}