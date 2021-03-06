using IntegradorProphetSys.Areas.PedidoEletronico.Data.Session;
using IntegradorProphetSys.Bibliotecas.Middleware;
using IntegradorProphetSys.Bibliotecas.Sessao;
using IntegradorProphetSys.DataBase.Contexts;
using IntegradorProphetSys.DataBase.Interfaces;
using IntegradorProphetSys.DataBase.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegradorProphetSys
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
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddDistributedMemoryCache();
            services.AddControllersWithViews();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<Session>();
            services.AddScoped<SessionPedidoEletronico>();
            services.AddScoped<SessionUsuario>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddDbContext<IntegradorSuasVendasContext>(options => options.UseNpgsql(Configuration.GetConnectionString("IntegradorProphetSysDb")));
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

            app.UseSession();

            app.UseMiddleware<ValidateAntiForgeryTokenMiddleware>();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Login}/{id?}"
                );
                routes.MapRoute(
                    name: "default",
                    template: "/{controller=Home}/{action=Login}/{id?}"
                );
            });

        }
    }
}
