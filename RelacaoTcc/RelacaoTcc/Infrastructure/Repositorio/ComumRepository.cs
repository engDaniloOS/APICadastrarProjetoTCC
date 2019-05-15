using Microsoft.EntityFrameworkCore;
using RelacaoTcc.Domain.Models.Interfaces;
using RelacaoTcc.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RelacaoTcc.Infrastructure.Repositorio
{
    public class ComumRepository<T> : IComumRepository<T> where T : Elemento
    {
        private readonly AppContexto contexto;
        private readonly DbSet<T> dbSet;

        public ComumRepository(AppContexto contexto)
        {
            this.contexto = contexto;
            this.dbSet = contexto.Set<T>();
        }

        public T BuscarPor(int id)
        {
            var resultado = dbSet.Where(q => q.Id == id);
            return resultado.Count() > 0 ? resultado.FirstOrDefault() : (T)Activator.CreateInstance(typeof(T));            
        }

        public List<T> Listar()
        {
            var resultado = dbSet.ToList();
            return resultado.Count > 0 ? resultado : new List<T>();
        }
    }
}
