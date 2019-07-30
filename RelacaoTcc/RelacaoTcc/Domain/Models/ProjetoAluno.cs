using System.Collections.Generic;

namespace RelacaoTcc.Dominio.Models
{
    public class ProjetoAluno
    {
        public int Id { get; private set; }
        public bool IsAtivo { get; set; }
        public int ProjetoId { get; set; }
        public int AlunoId { get; set; }
    }
}
