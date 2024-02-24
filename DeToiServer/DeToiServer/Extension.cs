using DeToiServer.Services.AccountService;
using DeToiServer.Services.OrderManagementService;
using DeToiServer.Services.ServiceCategoryService;
using DeToiServer.Services.ServiceInfoService;
using DeToiServer.Services.ServiceTypeService;
using DeToiServerData.Repositories;
using DeToiServerData.Repositories.CleaningServiceRepo;
using DeToiServerData.Repositories.OrderRepo;
using DeToiServerData.Repositories.PromotionRepo;
using DeToiServerData.Repositories.RepairingServiceRepo;
using DeToiServerData.Repositories.ServiceCategoryRepo;
using DeToiServerData.Repositories.ServiceTypeRepo;
using DeToiServerData.Repositories.ShoppingServiceRepo;
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
            services.AddScoped<IServiceCategoryRepo, ServiceCategoryRepo>();
            services.AddScoped<IPromotionRepo, PromotionRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<ICleaningServiceRepo, CleaningServiceRepo>();
            services.AddScoped<IRepairingServiceRepo, RepairingServiceRepo>();
            services.AddScoped<IShoppingServiceRepo, ShoppingServiceRepo>();
            services.AddScoped<IHomeInfoRepo, HomeInfoRepo>();
            services.AddScoped<UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddServicesData(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IServiceTypeService, ServiceTypeService>();
            services.AddScoped<IServiceCategoryService, ServiceCategoryService>();
            services.AddScoped<IOrderManagementService, OrderManagementService>();
            services.AddScoped<IHomeInfoService, HomeInfoService>();
            return services;
        }
    }
}
