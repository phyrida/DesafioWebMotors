using DesafioWebMotors.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioWebMotors.IoC;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;
using Newtonsoft.Json.Converters;

namespace DesafioWebMotors.Api
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
            ConfigDatabase(services);

            services.AddResponseCompression(
               options =>
               {
                   options.Providers.Add<BrotliCompressionProvider>();
                   options.Providers.Add<GzipCompressionProvider>();
               });

            services.Configure<BrotliCompressionProviderOptions>(
                options =>
                {
                    options.Level = CompressionLevel.Fastest;
                });

            services.Configure<GzipCompressionProviderOptions>(
                options =>
                {
                    options.Level = CompressionLevel.Fastest;
                });

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                        options.SerializerSettings.Converters.Add(new StringEnumConverter()));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DesafioWebMotors.Api", Version = "v1" });
            });

            services.AddDIConfiguration(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DesafioWebMotors.Api v1"));
            }
            app.UseCors(opt =>
            {
                opt.AllowAnyOrigin();
                opt.AllowAnyHeader();
                opt.AllowAnyMethod();
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

           

            CreateDatabase(app);
        }

        protected virtual void EnsureDatabaseCreated(DesafioWebmotorsContext dbContext)
        {
            dbContext.Database.Migrate();
        }

        protected virtual void ConfigDatabase(IServiceCollection services)
        {
            services.AddDbContext<DesafioWebmotorsContext>(options =>
            {
                options
                    .UseMySql(Configuration.GetConnectionString("Default"),
                    ServerVersion.Parse(Configuration["DataBase:Version"], Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql),
                    builder => builder.MigrationsAssembly("DesafioWebMotors.Data"));
            });
        }

        private void CreateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<DesafioWebmotorsContext>())
                {
                    EnsureDatabaseCreated(context);
                }
            }
        }
    }
}
