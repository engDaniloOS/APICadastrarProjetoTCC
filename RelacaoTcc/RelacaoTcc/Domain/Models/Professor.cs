namespace RelacaoTcc.Dominio.Models
{
    public class Professor : Elemento, IProfessor
    {
        public string Nome { get; set; }
        public string Registro { get; set; }
    }
}
