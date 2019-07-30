using System;

namespace RelacaoTcc.Domain.Models.DTO
{
    public class ProjetoModel : Model
    {
        public string Descricao { get; set; }
        public DateTime DataIni { get; set; }
        public DateTime DataFim { get; set; }
    }
}
