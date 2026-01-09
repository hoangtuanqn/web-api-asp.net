using Microsoft.EntityFrameworkCore;
using ShopDBProduct.Data;
using ShopDBProduct.Repositories.Implementations;
using ShopDBProduct.Repositories.Interfaces;
using ShopDBProduct.Services.Implementations;
using ShopDBProduct.Services.Interfaces;
using StackExchange.Redis;

namespace ShopDBProduct
{
    // phải là dạng static vì nó là method extends
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            return services;
        }

        public static IServiceCollection AddApplicationInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            // Connect String DB
            var connectStringDB = configuration.GetConnectionString("ConnectDB");
            var serverVersion = ServerVersion.AutoDetect(connectStringDB);
            services.AddDbContext<AppDbContext>(options => options.UseMySql(connectStringDB, serverVersion));

            // Connect String Redis
            var connectStringRedis = configuration.GetConnectionString("Redis");
            // ConnectionMultiplexer: mở kết nối tới server redis
            services.AddSingleton<IConnectionMultiplexer>(sp => ConnectionMultiplexer.Connect(connectStringRedis!));




            // Repository
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
