using Castle.Windsor.MsDependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebApplication5.Api.Filters;

namespace WebApplication5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc(x =>
                {
                    x.Filters.Add(new ModelValidationFilter());
                })
                .AddFluentValidation(x =>
                {
                    x.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                });

            return WindsorRegistrationHelper.CreateServiceProvider(
                WindsorConfiguration.BuildContainer(), services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
