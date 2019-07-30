using System;

namespace RelacaoTcc.Domain.Models.DTO
{
    public class ProjetoModel : IModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Registro { get; set; }
        public DateTime DataIni { get; set; }
        public DateTime DataFim { get; set; }
    }
}
