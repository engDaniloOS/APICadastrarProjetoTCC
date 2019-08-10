using System.Collections.Generic;

namespace RelacaoTcc.Domain.Models.DTO
{
    public class RelacaoPostModel
    {
        public int ProjetoId { get; set; }
        public int ProfessorId { get; set; }
        public List<int> AlunosId { get; set; }
    }
}
