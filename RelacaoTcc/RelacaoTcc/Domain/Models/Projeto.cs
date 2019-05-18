using RelacaoTcc.Domain.Models.Interfaces;
using System;

namespace RelacaoTcc.Dominio.Models
{
    public class Projeto : Elemento, INomeaveis, IProjeto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataIni { get; set; }
        public DateTime DataFim { get; set; }
    }
}
