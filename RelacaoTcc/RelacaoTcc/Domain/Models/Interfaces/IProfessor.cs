using RelacaoTcc.Domain.Models.Interfaces;

namespace RelacaoTcc.Dominio.Models
{
    public interface IProfessor : INomeaveis
    {
        string Registro { get; set; }
    }
}