﻿using RelacaoTcc.Domain.Models.DTO;
using RelacaoTcc.Dominio.Models;
using RelacaoTcc.Dominio.Services;
using RelacaoTcc.Infrastructure.Repositorio;
using RelacaoTcc.Infrastructure.Repositorio.Interface;

namespace RelacaoTcc.Domain.Services
{
    public class ProfessorService : ComumService<Professor, ProfessorModel>, IService<Professor, ProfessorModel>
    {
        public ProfessorService(IRepository<Professor, ProfessorModel> repository, IComumRepository<Professor> comum) : base(repository, comum) { }
    }
}
