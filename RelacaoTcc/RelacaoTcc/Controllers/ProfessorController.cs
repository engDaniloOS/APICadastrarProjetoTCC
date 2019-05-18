using Microsoft.AspNetCore.Mvc;
using RelacaoTcc.Domain.Models.DTO;
using RelacaoTcc.Dominio.Models;
using RelacaoTcc.Dominio.Services;

namespace RelacaoTcc.Controllers
{
    [ApiController]
    [Route("api/professor")]
    public class ProfessorController : ComumController<Professor, ProfessorModel>
    {
        public ProfessorController(IService<Professor, ProfessorModel> service) : base(service) { }
    }
}