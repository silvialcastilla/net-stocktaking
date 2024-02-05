using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using StockTaking.Persistence.Interfaces;
using StockTaking.Persistence.Repositories;

namespace StockTaking.Persistence
{
    //Inyección de dependencias
    public static class DependencyContainer
    {
        public static IServiceCollection AddContextSqlServer(this IServiceCollection services, IConfiguration configuration, string connectionString)
        {
            services.AddSqlServer<DataContext>(configuration.GetConnectionString("DefaultConnection"));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IMovementTypeRepository, MovementTypeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStockTakingMovementRepository, StockTakingMovementRepository>();
            services.AddScoped<IStockTakingStockRepository, StockTakingStockRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();

            return services;
        }

    }
}