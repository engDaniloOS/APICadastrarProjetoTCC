using System.Collections.Generic;

namespace RelacaoTcc.Dominio.Models
{
    public class ProjetoAluno
    {
        public int Id { get; private set; }
        public int ProjetoId { get; set; }
        public int AlunoId { get; set; }
        public Projeto Projeto { get; set; }
        public List<Aluno> Alunos { get; set; }
    }
}
