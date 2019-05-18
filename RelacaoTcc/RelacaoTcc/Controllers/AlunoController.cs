using Microsoft.AspNetCore.Mvc;
using RelacaoTcc.Dominio.Models;
using RelacaoTcc.Dominio.Models.DTO;
using RelacaoTcc.Dominio.Services;

namespace RelacaoTcc.Controllers
{
    [ApiController]
    [Route("api/aluno")]
    public class AlunoController : ComumController<Aluno, AlunoModel>
    {
        public AlunoController(IService<Aluno, AlunoModel> service) : base(service) { }
    }
}