using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NhibernateStarted.Repository;
using NhibernateStarted.Services;
using NhibernateStartedDomain.Entities;
using NhibernateStartedDomain.Interfaces;
using NhibernateStartedDomain.Repository;

namespace NhibernateStarted
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
            services.AddMvc();

            services.AddSingleton<ISessionFactory>(ConfigNhibernate.CreateSessionFactory());
            services.AddScoped<PessoaService>();
            services.AddScoped<IRepository<Pessoa>, Repository<Pessoa>>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //ConfigNhibernate.CreateSchema(true);
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
