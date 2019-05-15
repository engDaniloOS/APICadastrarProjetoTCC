using System.Collections.Generic;
using RelacaoTcc.Dominio.Models;

namespace RelacaoTcc.Infrastructure.Repositorio
{
    public interface IComumRepository<T> where T : Elemento
    {
        T BuscarPor(int Id);
        List<T> Listar();
    }
}