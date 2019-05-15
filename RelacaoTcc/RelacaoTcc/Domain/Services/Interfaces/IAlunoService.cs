using RelacaoTcc.Dominio.Models;
using RelacaoTcc.Dominio.Models.DTO;
using System.Collections.Generic;

namespace RelacaoTcc.Dominio.Services
{
    public interface IAlunoService
    {
        Aluno Criar(AlunoModel aluno);
        Aluno BuscarPor(int id);
        Aluno BuscarPor(string filtro);
        List<Aluno> Listar();
        List<Aluno> Filtrar(string filtro);
    }
}