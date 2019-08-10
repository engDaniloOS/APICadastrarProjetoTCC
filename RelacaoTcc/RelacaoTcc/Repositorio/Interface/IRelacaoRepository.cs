using RelacaoTcc.Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelacaoTcc.Repositorio.Interface
{
    public interface IRelacaoRepository
    {
        void Criar(RelacaoPostModel model);
    }
}
