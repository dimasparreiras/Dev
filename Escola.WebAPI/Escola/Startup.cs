using Escola.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
 
namespace Escola
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
            services.AddDbContext<EscolaContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("Default"))
            );
            
            services.AddControllers().AddNewtonsoftJson(
                opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddScoped<IRepository, Repository>();

            services.AddSwaggerGen( options =>
            {
                options.SwaggerDoc("escolaapi",
                new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Escola API",
                    Version = "1.0"
                });

                var XmlCommnetsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var XmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, XmlCommnetsFile);

                options.IncludeXmlComments(XmlCommentsFullPath);

            });
                

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/escolaapi/swagger.json", "escolaapi");
                options.RoutePrefix = "";
            });
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
