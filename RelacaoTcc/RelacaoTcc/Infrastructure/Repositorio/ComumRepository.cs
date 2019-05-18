using Microsoft.EntityFrameworkCore;
using RelacaoTcc.Domain.Models.Interfaces;
using RelacaoTcc.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RelacaoTcc.Infrastructure.Repositorio
{
    public abstract class ComumRepository<T> : IComumRepository<T> where T : Elemento, INomeaveis
    {
        #region Campos
        protected readonly AppContexto contexto;
        protected readonly DbSet<T> dbSet;
        #endregion

        #region Construtores
        public ComumRepository(AppContexto contexto)
        {
            this.contexto = contexto;
            this.dbSet = contexto.Set<T>();
        }
        #endregion

        #region Metodos
        public T BuscarPor(int id)
        {
            var resultado = dbSet.Where(q => (q.Id == id) && (q.IsAtivo));
            return resultado.Count() > 0 ? resultado.FirstOrDefault() : (T)Activator.CreateInstance(typeof(T));            
        }

        public List<T> Listar()
        {
            var resultado = dbSet.Where(q => q.IsAtivo).ToList();
            return resultado.Count > 0 ? resultado : new List<T>();
        }

        public void Excluir(int id)
        {
            var obj = dbSet.Find(id);
            obj.IsAtivo = false;
            dbSet.Update(obj);
            contexto.SaveChanges();
        }

        public T BuscarPor(string nome)
        {
            var resultado = dbSet.Where(q => (q.Nome.Equals(nome.ToLower())) && q.IsAtivo);
            return resultado.Count() > 0 ? resultado.FirstOrDefault() : Activator.CreateInstance<T>();
        }

        public List<T> Filtrar(string filtro)
        {
            return dbSet.Where(q => (q.Nome.ToLower().Contains(filtro)) && (q.IsAtivo)).ToList();
        }

        public T BuscarPorRegistro(string registro)
        {
            var resultado = dbSet.Where(q => q.Registro.Equals(registro.ToLower()));
            return resultado.Count() > 0 ? resultado.FirstOrDefault() : Activator.CreateInstance<T>();
        }
        #endregion
    }
}
