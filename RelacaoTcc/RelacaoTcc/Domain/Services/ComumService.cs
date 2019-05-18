using RelacaoTcc.Dominio.Models;
using RelacaoTcc.Infrastructure.Repositorio;
using RelacaoTcc.Infrastructure.Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RelacaoTcc.Domain.Services
{
    public abstract class ComumService<T, D> where T : Elemento 
    {
        #region Campos
        protected readonly IComumRepository<T> comum;
        protected readonly IRepository<T, D> repository;
        #endregion

        #region Construtores
        public ComumService(IRepository<T, D> repository, IComumRepository<T> comum)
        {
            this.repository = repository;
            this.comum = comum;
        }
        #endregion

        #region Metodos
        public T BuscarPor(int id)
        {
            try
            {
                return id > 0 ? comum.BuscarPor(id) : (T)Activator.CreateInstance(typeof(T));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<T> Listar()
        {
            try
            {
                List<T> alunos = comum.Listar();
                return alunos.Count > 0 ? alunos : new List<T>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                comum.Excluir(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T BuscarPor(string filtro)
        {
            Regex registro = new Regex("[0-9]{8}");

            try
            {
                return registro.IsMatch(filtro) ? repository.BuscarPorRegistro(filtro) : comum.BuscarPor(filtro);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<T> Filtrar(string filtro)
        {
            try
            {
                List<T> lista = comum.Filtrar(filtro);
                return lista.Count > 0 ? lista : new List<T>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public T Atualizar(D model)
        {
            try
            {
                var resultado = repository.Atualizar(model);
                return resultado.Id > 0 ? resultado : Activator.CreateInstance<T>();
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
}
