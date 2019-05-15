using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RelacaoTcc.Dominio.Models;

namespace RelacaoTcc.Controllers
{
    public abstract class ComumController<T> : Controller where T : Elemento
    {
        private readonly string acaoImpossivel = "Não foi possível executar a ação";
        private readonly string naoEncontrado = "Usuário(s) não encontrado(s)";

        protected IActionResult GerarResultado(T elemento, string mensagem = "")
        {
            if (elemento == null)
                return BadRequest(acaoImpossivel);

            else if (elemento.Id > 0)
                return Ok(elemento);

            else
                return BadRequest(mensagem);
        }

        protected IActionResult GerarLista(List<T> lista, string mensagem = "")
        {
            if (lista == null)
                return BadRequest(acaoImpossivel);

            else if (lista.Count == 0)
                return BadRequest(naoEncontrado);

            else
                return Ok(lista);
        }
    }
}