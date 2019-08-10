using RelacaoTcc.Dominio.Models;
using System.Collections.Generic;

namespace RelacaoTcc.Domain.Models.DTO
{
    public class RelacaoModel
    {
        public Projeto Projeto { get; set; }
        public Professor Professor { get; set; }
        public List<Aluno> Alunos { get; set; }
    }
}
