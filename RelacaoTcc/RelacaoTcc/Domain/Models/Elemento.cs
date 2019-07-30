namespace RelacaoTcc.Dominio.Models
{
    public abstract class Elemento
    {
        public string Nome { get; set; }
        public int Id { get; private set; }
        public bool IsAtivo { get; set; }
        public string Registro { get; set; }

        public override string ToString() => $"{Registro}/{Nome}";
    }
}
