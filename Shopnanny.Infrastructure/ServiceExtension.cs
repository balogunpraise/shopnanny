using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopnanny.Infrastructure.Data;

namespace Shopnanny.Infrastructure
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddInfrastructureConfiguration(this IServiceCollection service, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            service.AddDbContext<ApplicationDbContext>(option =>
            option.UseMySql(connectionString, serverVersion: ServerVersion.AutoDetect(connectionString)));
            //service.AddTransient<ITokenService, TokenService>();
            return service;
        }
    }
}
