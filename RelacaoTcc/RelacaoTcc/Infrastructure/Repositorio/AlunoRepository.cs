using RelacaoTcc.Dominio.Models;
using RelacaoTcc.Dominio.Models.DTO;
using RelacaoTcc.Infrastructure.Repositorio.Interface;
using System.Collections.Generic;
using System.Linq;

namespace RelacaoTcc.Infrastructure.Repositorio
{
    public class AlunoRepository : IAlunoRepository
    {
        public readonly AppContexto contexto;

        public AlunoRepository(AppContexto contexto)
        {
            this.contexto = contexto;
        }

        public Aluno Criar(AlunoModel model)
        {
            Aluno aluno = new Aluno()
            {
                IsAtivo = true,
                Nome = model.Nome,
                RA = model.RA,
                Profissao = model.Profissao,
                Celular = model.Celular
            };

            contexto.Add(aluno);
            contexto.SaveChanges();

            return aluno;
        }

        public Aluno BuscarPor(string nome)
        {
            var aluno = contexto.Alunos.Where(q => q.Nome.Equals(nome.ToLower()));
            return aluno.Count() > 0 ? aluno.FirstOrDefault() : new Aluno();
        }

        public Aluno BuscarPorRA(string ra)
        {
            var aluno = contexto.Alunos.Where(q => q.RA.Equals(ra.ToLower()));
            return aluno.Count() > 0 ? aluno.FirstOrDefault() : new Aluno();
        }

        public List<Aluno> Filtrar(string filtro)
        {
            return contexto.Alunos.Where(q => q.Nome.ToLower().Contains(filtro)).ToList();
        }
    }
}
