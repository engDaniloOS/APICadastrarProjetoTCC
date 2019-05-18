using System.Collections.Generic;

namespace RelacaoTcc.Dominio.Services
{
    public interface IService<T, D>
    {
        T Criar(D elemento);
        T BuscarPor(int id);
        T BuscarPor(string filtro);
        List<T> Listar();
        List<T> Filtrar(string filtro);
        T Atualizar(D elemento);
        bool Excluir(int id);
    }
}