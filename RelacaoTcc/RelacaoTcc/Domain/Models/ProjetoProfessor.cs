namespace RelacaoTcc.Dominio.Models
{
    public class ProjetoProfessor
    {
        public int Id { get; private set; }
        public int ProjetoId { get; set; }
        public int ProfessorId { get; set; }
        public Projeto Projeto { get; set; }
        public Professor Professores { get; set; }
    }
}
