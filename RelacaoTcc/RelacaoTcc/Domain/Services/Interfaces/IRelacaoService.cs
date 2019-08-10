using RelacaoTcc.Domain.Models.DTO;
using System.Collections.Generic;

namespace RelacaoTcc.Domain.Services
{
    public interface IRelacaoService
    {
        bool Criar(RelacaoPostModel model, ref string mensagem);
        List<RelacaoModel> BuscarProjetosPorProfessor(int professorId);
        RelacaoModel BuscarProjetoPorAluno(int alunoId);
        RelacaoModel BuscarProjeto(int id);
        RelacaoModel AlterarRelacao(RelacaoPostModel model, ref string mensagem);
    }
}
