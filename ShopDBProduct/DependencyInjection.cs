using Microsoft.EntityFrameworkCore;
using ShopDBProduct.Data;
using ShopDBProduct.Repositories.Implementations;
using ShopDBProduct.Repositories.Interfaces;
using ShopDBProduct.Services.Implementations;
using ShopDBProduct.Services.Interfaces;

namespace ShopDBProduct
{
    // phải là dạng static: là nơi chứa DI
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
          
            services.AddScoped<IProductService, ProductService>();
            //services.AddScoped<ICategoryService, CategoryService>();
            return services;
        }

        public static IServiceCollection AddApplicationInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            // Db Context
            var connectionString = configuration.GetConnectionString("ConnectDB");
            var serverVersion = ServerVersion.AutoDetect(connectionString);

            services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, serverVersion));

            // Repository
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
