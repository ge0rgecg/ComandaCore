using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Servico.Interface;
using Servico.Servicos;
using Swashbuckle.AspNetCore.Swagger;

namespace ComandaAPI
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
            //services.addDbContext
            services.AddSingleton<IComandaServico, ComandaServico>();
            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "George Cardillo Gregorio",
                        Email = "ge0rge.gcg@gmail.com"
                    },
                    Version = "v1",
                    Title = "Comanda API",
                    Description = "API para gerenciar comanda."
                });

                //options.DescribeAllEnumsAsStrings();
                //options.IncludeXmlComments(basePath);
                //options.SwaggerDoc("v1", new Info
                //{
                //    Title = settings.SwaggerTitle,
                //    Version = "v1",
                //    Description = settings.SwaggerDescription,
                //    Contact = new Contact
                //    {
                //        Name = "Procob IT Team",
                //        Email = "desenvolvimento@procobservicos.com.br"
                //    },
                //    License = new License
                //    {
                //        Name = "Finamax",
                //        Url = "http://www.finamax.com.br"
                //    }
                //});
                //options.AddSecurityDefinition("oauth2", new OAuth2Scheme
                //{
                //    Type = "oauth2",
                //    Flow = "application",
                //    TokenUrl = settings.SwaggerTokenUrl
                //});
                //options.OperationFilter<AuthorizeCheckOperationFilter>();
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

            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("v1/swagger.json", "Comanda API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
