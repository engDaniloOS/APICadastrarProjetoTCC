using RelacaoTcc.Domain.Models.DTO;
using RelacaoTcc.Dominio.Models;
using RelacaoTcc.Infrastructure.Repositorio;
using RelacaoTcc.Infrastructure.Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RelacaoTcc.Domain.Services
{
    public abstract class ComumService<T, D> where T : Elemento where D : IModel
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
        public T Criar(D model)
        {
            try
            {
                var elemento = Activator.CreateInstance<T>();

                if (!string.IsNullOrEmpty(model.Nome.Trim()) && !string.IsNullOrEmpty(model.Registro.Trim()))
                {
                    if (repository.BuscarPorRegistro(model.Registro).Id == 0 && comum.BuscarPor(model.Nome).Id == 0)
                        elemento = repository.Criar(model);

                    return elemento;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public T BuscarPor(int id)
        {
            try
            {
                return comum.BuscarPor(id);
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
                return comum.Listar();
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
