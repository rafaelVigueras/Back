using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Back.Application.Interface;
using Back.Application.Main;
using Back.Domain.Core;
using Back.Domain.Interface;
using Back.Infrastructure.Interface;
using Back.Infrastructure.Repository;
using Back.Services.WebAPI.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Back.Services.WebAPI
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
            services.AddCors();
            services.AddMvc();


            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingsProfile());
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<ISystemUserApplication, SystemUserApplication>();
            services.AddScoped<ISystemUserDomain, SystemUserDomain>();
            services.AddScoped<ISystemUserRepository, SystemUserRepository>();

            services.AddCors();
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x =>
            x.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseRouting();  
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
