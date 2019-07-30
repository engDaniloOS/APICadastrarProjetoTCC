using System.Collections.Generic;

namespace RelacaoTcc.Infrastructure.Repositorio.Interface
{
    public interface IRepository<T, D>
    {
        T Criar(D model);
        T BuscarPorRegistro(string registro);
        T Atualizar(D model);
    }
}
