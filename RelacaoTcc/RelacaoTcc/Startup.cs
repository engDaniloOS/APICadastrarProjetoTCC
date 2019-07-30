using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RelacaoTcc.Domain.Models.DTO;
using RelacaoTcc.Domain.Services;
using RelacaoTcc.Dominio.Models;
using RelacaoTcc.Dominio.Models.DTO;
using RelacaoTcc.Dominio.Services;
using RelacaoTcc.Infrastructure;
using RelacaoTcc.Infrastructure.Repositorio;
using RelacaoTcc.Infrastructure.Repositorio.Interface;

namespace RelacaoTcc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<AppContexto>(option => option.UseSqlServer(Configuration.GetConnectionString("Default")));

            #region Dependency Injection
            services.AddTransient<IService<Aluno, AlunoModel>, AlunoService>();
            services.AddTransient<IService<Professor, ProfessorModel>, ProfessorService>();
            services.AddTransient<IService<Projeto, ProjetoModel>, ProjetoService>();

            services.AddTransient<IRepository<Aluno, AlunoModel>, AlunoRepository>();
            services.AddTransient<IRepository<Professor, ProfessorModel>, ProfessorRepository>();
            services.AddTransient<IRepository<Projeto, ProjetoModel>, ProjetoRepository>();

            services.AddTransient<IComumRepository<Aluno>, AlunoRepository>();
            services.AddTransient<IComumRepository<Professor>, ProfessorRepository>();
            services.AddTransient<IComumRepository<Projeto>, ProjetoRepository>();
            #endregion Dependency Injection
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
