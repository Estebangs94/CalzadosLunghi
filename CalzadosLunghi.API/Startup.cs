using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3;
using AutoMapper;
using CalzadosLunghi.API.Middleware;
using CalzadosLunghi.Core.Implementations;
using CalzadosLunghi.Core.Interfaces;
using CalzadosLunghi.Data;
using CalzadosLunghi.Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CalzadosLunghi.API
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
            services.AddControllers();
            services.AddControllersWithViews();
            services.AddDbContextPool<CalzadosLunghiDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("CalzadosLunghiDb"))
                       .EnableSensitiveDataLogging();
            });
            services.AddScoped<ITipoMaterialData, SqlTipoMaterialData>();
            services.AddScoped<IMaterialData, SqlMaterialData>();
            services.AddScoped<IColorData, SqlColorData>();
            services.AddScoped<IParteZapatoData, SqlParteZapatoData>();

            services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
            services.AddAWSService<IAmazonS3>();

            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IFileCloudProviderService, AmazonFileService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<FeaturesSwitchMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseMiddleware<FeatureSwitchAuthMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
