using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CyberTech.DataAccess
{
    public static class DBConfiguration
    {
        public static IServiceCollection ConfigureContext(this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(optionsBuilder
                => optionsBuilder
                    //.UseNpgsql(connectionString));
                    .UseLazyLoadingProxies()
                    .UseSqlServer(connectionString));
            return services;
        }
    }
}
