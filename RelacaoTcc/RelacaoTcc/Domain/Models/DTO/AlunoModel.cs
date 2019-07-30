using RelacaoTcc.Domain.Models.DTO;

namespace RelacaoTcc.Dominio.Models.DTO
{
    public class AlunoModel : IModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Registro { get; set; }
        public string Profissao { get; set; }
        public string Celular { get; set; }
    }
}
