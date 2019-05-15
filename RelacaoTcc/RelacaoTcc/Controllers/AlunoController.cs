using Microsoft.AspNetCore.Mvc;
using RelacaoTcc.Dominio.Models;
using RelacaoTcc.Dominio.Models.DTO;
using RelacaoTcc.Dominio.Services;
using System.Collections.Generic;

namespace RelacaoTcc.Controllers
{
    [ApiController]
    public class AlunoController : ComumController<Aluno>
    {
        private readonly string jaCadastrado = "Usuário já cadastrado";
        private readonly string naoEncontrado = "Usuário(s) não encontrado(s)";

        public readonly IAlunoService service;

        public AlunoController(IAlunoService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("api/aluno")]
        public IActionResult Criar([FromBody]AlunoModel model)
        {
            return GerarResultado(service.Criar(model), jaCadastrado);
        }

        [HttpGet]
        [Route("api/aluno/id/{id}")]
        public IActionResult BuscarPor(int id)
        {
            return GerarResultado(service.BuscarPor(id));
        }

        [HttpGet]
        [Route("api/aluno/filtro/{filtro}")]
        public IActionResult BuscarPor(string filtro)
        {
            return GerarResultado(service.BuscarPor(filtro), naoEncontrado);
        }

        [HttpGet]
        [Route("api/aluno/buscar/{filtro}")]
        public IActionResult Filtrar(string filtro)
        {
            return GerarLista(service.Filtrar(filtro));
        }

        [HttpGet]
        [Route("api/aluno")]
        public IActionResult Listar(string filtro)
        {
            return GerarLista(service.Listar());
        }
    }
}