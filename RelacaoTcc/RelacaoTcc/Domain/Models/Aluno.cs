using RelacaoTcc.Domain.Models.Interfaces;

namespace RelacaoTcc.Dominio.Models
{
    public class Aluno : Elemento, INomeaveis, IAluno
    {
        public string Nome { get; set; }
        public string Profissao { get; set; }
        public string Celular { get; set; }
    }
}
