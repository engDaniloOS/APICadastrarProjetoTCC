using RelacaoTcc.Dominio.Models;
using RelacaoTcc.Dominio.Models.DTO;
using RelacaoTcc.Infrastructure.Repositorio.Interface;
using System.Linq;

namespace RelacaoTcc.Infrastructure.Repositorio
{
    public class AlunoRepository : ComumRepository<Aluno>, IRepository<Aluno, AlunoModel>
    {
        public AlunoRepository(AppContexto contexto) : base(contexto)
        {
        }

        public Aluno Criar(AlunoModel model)
        {
            Aluno aluno = new Aluno()
            {
                IsAtivo = true,
                Nome = model.Nome,
                Registro = model.RA,
                Profissao = model.Profissao,
                Celular = model.Celular
            };

            contexto.Add(aluno);
            contexto.SaveChanges();

            return aluno;
        }

        public Aluno Atualizar(AlunoModel aluno)
        {
            var resultado = contexto.Alunos.Where(q => (q.Id == aluno.Id) && q.IsAtivo ).FirstOrDefault();

            resultado.Profissao = string.IsNullOrWhiteSpace(aluno.Profissao) ? resultado.Profissao : aluno.Profissao;
            resultado.Celular = string.IsNullOrWhiteSpace(aluno.Celular) ? resultado.Celular : aluno.Celular;
            contexto.Update(resultado);
            contexto.SaveChanges();

            return resultado;
        }
    }
}
