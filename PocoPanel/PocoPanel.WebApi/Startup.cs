using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PocoPanel.Application;
using PocoPanel.Application.Interfaces;
using PocoPanel.Infrastructure.Identity;
using PocoPanel.Infrastructure.Persistence;
using PocoPanel.Infrastructure.Persistence.Contexts;
using PocoPanel.Infrastructure.Shared;
using PocoPanel.WebApi.Extensions;
using PocoPanel.WebApi.Models;
using PocoPanel.WebApi.Services;

namespace PocoPanel.WebApi
{
    public class Startup
    {
        public IConfiguration _config { get; }
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationLayer();
            services.AddIdentityInfrastructure(_config);
            services.AddPersistenceInfrastructure(_config);
            services.AddSharedInfrastructure(_config);
            services.AddSwaggerExtension();
            services.AddControllers();
            services.AddApiVersioningExtension();
            services.AddHealthChecks();

            services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwaggerExtension();
            app.UseErrorHandlingMiddleware();
            app.UseHealthChecks("/health");
            app.UseResponseCaching();

            #region Header Response

            app.Use(async (context, next) =>
             {
                 context.Response.Headers.Add("X-Site", "www.PocoPanel.ir");
                 await next();
             });

            #endregion
            app.UseEndpoints(endpoints =>
             {
                 endpoints.MapControllers();
             });
        }

    }
}
