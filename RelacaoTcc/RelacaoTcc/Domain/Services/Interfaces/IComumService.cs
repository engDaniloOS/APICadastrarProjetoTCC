using System.Collections.Generic;
using RelacaoTcc.Dominio.Models;

namespace RelacaoTcc.Domain.Services
{
    public interface IComumService<T> where T : Elemento
    {
        T BuscarPor(int id);
        bool Excluir(int id);
        List<T> Listar();
    }
}