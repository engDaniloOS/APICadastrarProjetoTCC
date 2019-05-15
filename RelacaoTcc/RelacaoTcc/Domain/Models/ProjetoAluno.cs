namespace RelacaoTcc.Dominio.Models
{
    public class ProjetoAluno : Elemento, IProjetoAluno
    {
        public int ProjetoId { get; set; }
        public int AlunoId { get; set; }
    }
}
