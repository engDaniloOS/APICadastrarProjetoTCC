using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RelacaoTcc.Dominio.Models;
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

            services.AddTransient<IAlunoService, AlunoService>();
            services.AddTransient<IAlunoRepository, AlunoRepository>();
            services.AddTransient<IComumRepository<Aluno>, ComumRepository<Aluno>>();
            services.AddTransient<IComumRepository<Professor>, ComumRepository<Professor>>();
            services.AddTransient<IComumRepository<Projeto>, ComumRepository<Projeto>>();



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
