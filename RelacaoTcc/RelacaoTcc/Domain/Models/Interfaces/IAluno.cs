using RelacaoTcc.Domain.Models.Interfaces;

namespace RelacaoTcc.Dominio.Models
{
    public interface IAluno : INomeaveis
    {
        string Celular { get; set; }
        string Nome { get; set; }
        string Profissao { get; set; }
        string RA { get; set; }
    }
}