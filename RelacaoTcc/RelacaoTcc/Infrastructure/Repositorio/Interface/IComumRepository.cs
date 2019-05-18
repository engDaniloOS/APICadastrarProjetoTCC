using RelacaoTcc.Dominio.Models;
using System.Collections.Generic;

namespace RelacaoTcc.Infrastructure.Repositorio
{
    public interface IComumRepository<T> where T : Elemento 
    {
        T BuscarPor(int Id);
        T BuscarPor(string nome);
        void Excluir(int id);
        T BuscarPorRegistro(string registro);
        List<T> Filtrar(string filtro);
        List<T> Listar();
    }
}