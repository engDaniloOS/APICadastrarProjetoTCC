namespace RelacaoTcc.Dominio.Models
{
    public abstract class Elemento
    {
        public int Id { get; private set; }
        public bool IsAtivo { get; set; }
        public string Registro { get; set; }
    }
}
