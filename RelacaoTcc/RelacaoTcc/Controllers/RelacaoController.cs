using Microsoft.AspNetCore.Mvc;
using RelacaoTcc.Domain.Models.DTO;
using RelacaoTcc.Domain.Services;
using System.Collections.Generic;

namespace RelacaoTcc.Controllers
{
    [ApiController]
    [Route("api/relacao")]
    public class RelacaoController : Controller
    {
        #region campos
        private readonly IRelacaoService service;
        private readonly string badRequestMsg = "Não foi possível executar a ação!";
        private readonly string naoEncontradoMsg = "Projeto(s) não encontrado!";
        private readonly string okMsg = "Comando executado com sucesso!";
        #endregion campos

        #region construtor
        public RelacaoController(IRelacaoService service)
        {
            this.service = service;
        }
        #endregion construtor

        #region métodos auxiliares

        private ActionResult GerarResultado(RelacaoModel model)
        {
            if (model == null)
                return BadRequest(badRequestMsg);

            else if (model.Projeto == null || model.Projeto.Id == 0)
                return NotFound(naoEncontradoMsg);

            return Ok(model);
        }

        private ActionResult GerarResultado(List<RelacaoModel> lista)
        {
            if (lista == null)
                return BadRequest(badRequestMsg);

            else if (lista.Count == 0)
                return NotFound(naoEncontradoMsg);

            return Ok(lista);
        }

        #endregion métodos auxiliares

        #region métodos
        [HttpPost]
        public ActionResult Criar([FromBody] RelacaoPostModel model)
        {
            string mensagem = string.Empty;

            if (service.Criar(model, ref mensagem))
                return Ok(okMsg);

            return BadRequest($"{badRequestMsg}. Error: {mensagem}");
        }

        [HttpGet]
        [Route("buscarPorProfessorId/{id}")]
        public ActionResult BuscarPorProfessor(int id)
            => GerarResultado(service.BuscarProjetosPorProfessor(id));

        [HttpGet]
        [Route("buscarPorAlunorId/{id}")]
        public ActionResult BuscarPorAluno(int id)
            => GerarResultado(service.BuscarProjetoPorAluno(id));

        [HttpGet]
        [Route("buscarPorProjetoId/{id}")]
        public ActionResult BuscarPorProjeto(int id)
            => GerarResultado(service.BuscarProjeto(id));

        [HttpPut]
        [Route("alterarRelacao")]
        public ActionResult AlterarRelacao([FromBody] RelacaoPostModel model)
        {
            string mensagem = string.Empty;
            return GerarResultado(service.AlterarRelacao(model, ref mensagem));
        }

        #endregion métodos
    }
}