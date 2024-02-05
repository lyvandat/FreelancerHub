using DeToiServer.Services.AccountService;
using DeToiServer.Services.ServiceTypeService;
using DeToiServerData.Repositories;
using DeToiServerData.Repositories.ServiceRepo;
using DeToiServerData.Repositories.ServiceTypeRepo;
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
            services.AddScoped<IServiceTypeRepo, ServiceTypeRepo>();
            services.AddScoped<UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddServicesData(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IServiceTypeService, ServiceTypeService>();
            return services;
        }
    }
}
