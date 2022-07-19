using Microsoft.EntityFrameworkCore;
using ShoppingCart.Contracts;
using ShoppingCart.Contracts.IRepositories;
using ShoppingCart.Contracts.IServices;
using ShoppingCart.Entities.Data;
using ShoppingCart.Repositories;
using ShoppingCart.Services;
using ShoppingCart.Services.LoggerService;

namespace ShoppingCart.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddDatabaseConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShoppingCartDatabaseContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ShoppingCart"),
            b => b.MigrationsAssembly("ShoppingCart.API")));
        }

        public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) => services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) => services.AddScoped<IServiceManager, ServiceManager>();
    }
}
