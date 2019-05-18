using RelacaoTcc.Domain.Models.Interfaces;

namespace RelacaoTcc.Dominio.Models
{
    public interface IAluno : INomeaveis
    {
        string Celular { get; set; }
        string Profissao { get; set; }
        string Registro { get; set; }
    }
}