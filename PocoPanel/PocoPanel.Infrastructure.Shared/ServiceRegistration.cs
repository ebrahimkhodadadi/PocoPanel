using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PocoPanel.Application.Interfaces;
using PocoPanel.Domain.Settings;
using PocoPanel.Infrastructure.Shared.Services;

namespace PocoPanel.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<MailSettings>(_config.GetSection("MailSettings"));
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
