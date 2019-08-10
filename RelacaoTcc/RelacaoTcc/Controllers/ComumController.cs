using Microsoft.AspNetCore.Mvc;
using RelacaoTcc.Domain.Models.DTO;
using RelacaoTcc.Dominio.Models;
using RelacaoTcc.Dominio.Services;
using System.Collections.Generic;

namespace RelacaoTcc.Controllers
{
    public abstract class ComumController<T, D> : Controller where T : Elemento where D : IModel
    {
        #region Campos
        public readonly IService<T, D> service;

        public readonly string acaoImpossivel = "Não foi possível executar a ação";
        public readonly string naoEncontrado = "Item não encontrado";
        public readonly string jaCadastrado = "Item já cadastrado";
        #endregion

        #region construtor
        public ComumController(IService<T, D> service)
        {
            this.service = service;
        }
        #endregion

        #region métodos auxiliares
        public IActionResult GerarResultado(T elemento, string mensagem = "")
        {
            if (elemento == null)
                return BadRequest(acaoImpossivel);

            else if (elemento.Id == 0)
                return NotFound(naoEncontrado);

            else if (elemento.Id > 0)
                return Ok(elemento);

            return BadRequest(mensagem);
        }

        public IActionResult GerarLista(List<T> lista, string mensagem = "")
        {
            if (lista == null)
                return BadRequest(acaoImpossivel);

            else if (lista.Count == 0)
                return NotFound(naoEncontrado);

            return Ok(lista);
        }
        #endregion métodos auxiliares

        #region Métodos
        [HttpPost]
        public virtual IActionResult Criar([FromBody]D model)
            => GerarResultado(service.Criar(model), jaCadastrado);

        [HttpGet]
        [Route("id/{id}")]
        public IActionResult BuscarPor(int id)
            => GerarResultado(service.BuscarPor(id), naoEncontrado);

        [HttpGet]
        [Route("buscar/{filtro}")]
        public IActionResult BuscarPor(string filtro)
            => GerarResultado(service.BuscarPor(filtro), naoEncontrado);

        [HttpGet]
        [Route("filtrar/{filtro}")]
        public IActionResult Filtrar(string filtro)
            => GerarLista(service.Filtrar(filtro), naoEncontrado);

        [HttpGet]
        public IActionResult Listar(string filtro)
            => GerarLista(service.Listar(), naoEncontrado);

        [HttpPut]
        [Route("atualizar")]
        public IActionResult Atualizar([FromBody]D objeto)
            => GerarResultado(service.Atualizar(objeto), "Não foi possível atualizar os dados.");

        [HttpDelete]
        [Route("excluir")]
        public IActionResult Excluir([FromBody]int id)
        {
            if (service.Excluir(id))
                return NoContent();

            return BadRequest("O ítem não pode ser excluído!");
        }

        #endregion
    }
}