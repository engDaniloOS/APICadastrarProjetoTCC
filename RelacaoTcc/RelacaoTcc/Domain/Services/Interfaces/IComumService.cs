using System.Collections.Generic;
using RelacaoTcc.Domain.Models.DTO;
using RelacaoTcc.Dominio.Models;

namespace RelacaoTcc.Domain.Services
{
    public interface IComumService<T, D>
        where T : Elemento
        where D : IModel
    {
        T Atualizar(D model);
        T BuscarPor(int id);
        T BuscarPor(string filtro);
        T Criar(D model);
        bool Excluir(int id);
        List<T> Filtrar(string filtro);
        List<T> Listar();
    }
}