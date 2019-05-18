using Microsoft.AspNetCore.Mvc;
using RelacaoTcc.Dominio.Models;
using RelacaoTcc.Dominio.Services;
using System.Collections.Generic;

namespace RelacaoTcc.Controllers
{
    public abstract class ComumController<T, D> : Controller where T : Elemento
    {
        #region Campos
        protected readonly string acaoImpossivel = "Não foi possível executar a ação";
        protected readonly string naoEncontrado = "Usuário(s) não encontrado(s)";
        protected readonly string jaCadastrado = "Usuário já cadastrado";

        public readonly IService<T, D> service;
        #endregion

        #region construtor
        public ComumController(IService<T, D> service)
        {
            this.service = service;
        }
        #endregion

        #region Métodos
        private IActionResult GerarResultado(T elemento, string mensagem = "")
        {
            if (elemento == null)
                return BadRequest(acaoImpossivel);

            else if (elemento.Id > 0)
                return Ok(elemento);

            else
                return BadRequest(mensagem);
        }

        private IActionResult GerarLista(List<T> lista, string mensagem = "")
        {
            if (lista == null)
                return BadRequest(acaoImpossivel);

            else if (lista.Count == 0)
                return BadRequest(naoEncontrado);

            else
                return Ok(lista);
        }

        [HttpPost]
        public virtual IActionResult Criar([FromBody]D model)
        {
            return GerarResultado(service.Criar(model), jaCadastrado);
        }

        [HttpGet]
        [Route("id/{id}")]
        public IActionResult BuscarPor(int id)
        {
            return GerarResultado(service.BuscarPor(id), naoEncontrado);
        }

        [HttpGet]
        [Route("buscar/{filtro}")]
        public IActionResult BuscarPor(string filtro)
        {
            return GerarResultado(service.BuscarPor(filtro), naoEncontrado);
        }

        [HttpGet]
        [Route("filtrar/{filtro}")]
        public IActionResult Filtrar(string filtro)
        {
            return GerarLista(service.Filtrar(filtro), naoEncontrado);
        }

        [HttpGet]
        public IActionResult Listar(string filtro)
        {
            return GerarLista(service.Listar(), naoEncontrado);
        }

        [HttpPut]
        [Route("atualizar")]
        public IActionResult Atualizar([FromBody]D aluno)
        {
            return GerarResultado(service.Atualizar(aluno), "Não foi possível atualizar os dados.");
        }

        [HttpDelete]
        [Route("excluir")]
        public IActionResult Excluir([FromBody]int id)
        {
            var resultado = service.Excluir(id);

            if (resultado)
                return Ok("Item excluído com sucesso!");
            else
                return BadRequest("O ítem não pode ser excluído!");
        }

        #endregion
    }
}