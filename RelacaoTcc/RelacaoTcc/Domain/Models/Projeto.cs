using System;

namespace RelacaoTcc.Dominio.Models
{
    public class Projeto : Elemento, IProjeto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataIni { get; set; }
        public DateTime DataFim { get; set; }
    }
}
