using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MLGDataAccessLayer;
using Microsoft.EntityFrameworkCore;
using MLGBussinesLogic.interfaces;
using MLGBussinesLogic.services;
using System;
using Microsoft.OpenApi.Models;
using MLGBussinessLogic.interfaces;
using MLGBussinessLogic.services;
using Microsoft.Extensions.FileProviders;
using System.IO;
using MLGBussinessLogic.middleware;

namespace MLGApi
{
    //public static class ServiceCollectionExtensions
    //{
    //    // Add parameters if required, e.g. for configuration
    //    public static IServiceCollection AddDAL(this IServiceCollection services)
    //    {
    //        // Register all services as required
    //        return services
    //          .AddScoped<IInterfaceFromBL, ImplementationFromDAL>();
    //    }
    //}
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<JwtMiddleware>();
            services.AddSingleton<HashMiddleware>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IArticuloRepository, ArticuloRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IUsuarioClienteRepository, UsuarioClienteRepository>();

            services.AddScoped<ITiendaRepository, TiendaRepository>();
            services.AddScoped<ITiendaArticuloRepository, TiendaArticuloRepository>();

            AddSwagger(services);
       

            services.AddDbContext<AppDBContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection"), b => b.MigrationsAssembly("MLGDataAccessLayer")));

           
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => {
                    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });


            services.AddControllers();
        }
        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Foo {groupName}",
                    Version = groupName,
                    Description = "Foo API",
                    Contact = new OpenApiContact
                    {
                        Name = "Foo Company",
                        Email = string.Empty,
                        Url = new Uri("https://foo.com/"),
                    }
                });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foo API V1");
            });

            app.UseRouting();
            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseStaticFiles();
        }
    }
}
