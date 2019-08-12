using RelacaoTcc.Domain.Models.DTO;

namespace RelacaoTcc.Repositorio.Interface
{
    public interface IRelacaoRepository
    {
        void Criar(RelacaoPostModel model);
        void VerificaProjetoAssociado(int id);
        void VerificaAlunoAssociado(int id);
    }
}
