using DemoDI.Cases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DemoDI
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
            #region [-- VidaReal --]

            // Injeção de dependência usando Microsoft.Extensions.DependencyInjection (nativo do .Net)
            // Outros exemplos de containers IoC (https://www.palmmedia.de/blog/2011/8/30/ioc-container-benchmark-performance-comparison)
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteServices, ClienteServices>();

            #endregion

            #region [-- Lifecycle --]

            // AddTransient (Transitório): são criados cada vez que são usados pelo contêiner de serviço.
            services.AddTransient<IOperacaoTransient, Operacao>();
            // AddScoped (Com escopo): são criados a cada nova requisição do cliente (conexão).
            services.AddScoped<IOperacaoScoped, Operacao>();
            // AddSingleton: são criados na primeira vez que forem requisitados e cada requisição subsequente usa a mesma instância já criada.
            services.AddSingleton<IOperacaoSingleton, Operacao>();
            services.AddSingleton<IOperacaoSingletonInstance>(new Operacao(Guid.Empty));
            services.AddTransient<OperacaoService>();

            #endregion

            #region [-- Generics --]

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            #endregion

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
