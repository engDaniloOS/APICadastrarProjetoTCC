namespace RelacaoTcc.Dominio.Models
{
    public class Aluno : Elemento, IAluno
    {
        public string Nome { get; set; }
        public string RA { get; set; }
        public string Profissao { get; set; }
        public string Celular { get; set; }
    }
}
