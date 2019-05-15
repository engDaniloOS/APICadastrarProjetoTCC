using System.Collections.Generic;
using RelacaoTcc.Dominio.Models;
using RelacaoTcc.Dominio.Models.DTO;

namespace RelacaoTcc.Infrastructure.Repositorio.Interface
{
    public interface IAlunoRepository
    {
        Aluno BuscarPorRA(string ra);
        Aluno Criar(AlunoModel model);
        Aluno BuscarPor(string nome);
        List<Aluno> Filtrar(string filtro);
    }
}
