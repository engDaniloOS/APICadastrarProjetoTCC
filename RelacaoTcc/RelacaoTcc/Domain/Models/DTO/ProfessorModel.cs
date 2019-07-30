namespace RelacaoTcc.Domain.Models.DTO
{
    public class ProfessorModel : IModel
    {
        public int Id { get; set; }
        public bool IsAtivo { get; set; }
        public string Nome { get; set; }
        public string Registro { get; set; }
    }
}
