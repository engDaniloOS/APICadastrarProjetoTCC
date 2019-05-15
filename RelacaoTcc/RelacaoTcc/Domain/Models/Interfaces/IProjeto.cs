using RelacaoTcc.Domain.Models.Interfaces;
using System;

namespace RelacaoTcc.Dominio.Models
{
    public interface IProjeto : INomeaveis
    {
        DateTime DataFim { get; set; }
        DateTime DataIni { get; set; }
        string Descricao { get; set; }
    }
}