namespace RelacaoTcc.Dominio.Models
{
    public class ProjetoProfessor : Elemento, IProjetoProfessor
    {
        public int ProjetoId { get; set; }
        public int ProfessorId { get; set; }
    }
}
