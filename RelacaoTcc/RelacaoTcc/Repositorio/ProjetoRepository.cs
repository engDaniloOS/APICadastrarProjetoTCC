using RelacaoTcc.Domain.Models.DTO;
using RelacaoTcc.Dominio.Models;
using RelacaoTcc.Infrastructure.Repositorio.Interface;
using System.Linq;

namespace RelacaoTcc.Infrastructure.Repositorio
{
    public class ProjetoRepository : ComumRepository<Projeto>, IRepository<Projeto, ProjetoModel>
    {
        private const string patternDate = "dd/MM/yyyy";

        public ProjetoRepository(AppContexto contexto) : base(contexto)
        {
        }

        public Projeto Atualizar(ProjetoModel projeto)
        {
            var resultado = contexto.Projetos.Where(q => (q.Id == projeto.Id) && q.IsAtivo).FirstOrDefault();

            resultado.Descricao = string.IsNullOrWhiteSpace(projeto.Descricao) ? resultado.Descricao : projeto.Descricao;
            resultado.DataIni = string.IsNullOrWhiteSpace(projeto.DataIni.ToString(patternDate)) ? resultado.DataIni : projeto.DataIni;
            resultado.DataFim = string.IsNullOrWhiteSpace(projeto.DataFim.ToString(patternDate)) ? resultado.DataFim : projeto.DataFim;

            contexto.Update(resultado);
            contexto.SaveChanges();

            return resultado;
        }

        public Projeto Criar(ProjetoModel model)
        {
            Projeto projeto = new Projeto()
            {
                IsAtivo = true,
                Nome = model.Nome,
                Registro = model.Registro,
                Descricao = model.Descricao,
                DataIni = model.DataIni,
                DataFim = model.DataFim,
            };

            contexto.Add(projeto);
            contexto.SaveChanges();

            return projeto;
        }
    }
}
