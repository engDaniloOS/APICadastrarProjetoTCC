namespace RelacaoTcc.Domain.Models.DTO
{
    public abstract class Model : IModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Registro { get; set; }
    }
}
