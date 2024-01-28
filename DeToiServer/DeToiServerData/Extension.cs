using DeToiServerData.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DeToiServerData
{
    public static class Extension
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
        {
            services.AddDbContext<DataContext>(optionsAction);
            services.AddScoped<IAccountRepo, AccountRepo>();
            services.AddScoped<UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddServicesData(this IServiceCollection services)
        {
            return services;
        }
    }
}
