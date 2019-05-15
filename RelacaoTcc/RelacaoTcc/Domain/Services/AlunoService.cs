using RelacaoTcc.Dominio.Models;
using RelacaoTcc.Dominio.Models.DTO;
using RelacaoTcc.Infrastructure.Repositorio;
using RelacaoTcc.Infrastructure.Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RelacaoTcc.Dominio.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository repository;
        private readonly IComumRepository<Aluno> comum; 

        public AlunoService(IAlunoRepository repository, IComumRepository<Aluno> comum)
        {
            this.repository = repository;
            this.comum = comum;
        }
        public Aluno Criar(AlunoModel model)
        {
            try
            {
                var aluno = new Aluno();

                if (!string.IsNullOrEmpty(model.Nome.Trim()) && !string.IsNullOrEmpty(model.RA.Trim()))
                {
                    if (repository.BuscarPorRA(model.RA).Id == 0 && repository.BuscarPor(model.Nome).Id == 0)
                        aluno = repository.Criar(model);

                    return aluno;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Aluno BuscarPor(int id)
        {
            try
            {
                return id > 0 ? comum.BuscarPor(id) : new Aluno();
            }
            catch (Exception)
            {
                return null;
            }    
        }

        public Aluno BuscarPor(string filtro)
        {
            Regex ra = new Regex("[0-9]{8}");

            try
            {
                return ra.IsMatch(filtro) ? repository.BuscarPorRA(filtro) : repository.BuscarPor(filtro);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Aluno> Listar()
        {
            try
            {
                List<Aluno> alunos = comum.Listar();
                return alunos.Count > 0 ? alunos : new List<Aluno>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Aluno> Filtrar(string filtro)
        {
            try
            {
                List<Aluno> alunos = repository.Filtrar(filtro);
                return alunos.Count > 0 ? alunos : new List<Aluno>();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
