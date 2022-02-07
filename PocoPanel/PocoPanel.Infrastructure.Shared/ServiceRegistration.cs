using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PocoPanel.Application.Interfaces;
using PocoPanel.Domain.Settings;
using PocoPanel.Infrastructure.Shared.Services;
using PocoPanel.WebApi.Models;

namespace PocoPanel.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<MailSettings>(_config.GetSection("MailSettings"));
            services.Configure<WebsiteModel>(_config.GetSection("website"));
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<IConvert, ConvertService>();
        }
    }
}
