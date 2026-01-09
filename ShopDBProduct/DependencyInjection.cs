using Microsoft.EntityFrameworkCore;
using ShopDBProduct.Data;
using ShopDBProduct.Repositories.Implementations;
using ShopDBProduct.Repositories.Interfaces;
using ShopDBProduct.Services.Implementations;
using ShopDBProduct.Services.Interfaces;

namespace ShopDBProduct
{
    // phải là dạng static vì nó là method extends
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // add những service
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }

        public static IServiceCollection AddApplicationInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            // Db Context
            var connectionString = configuration.GetConnectionString("ConnectDB");
            if(connectionString == null)
            {
                throw new InvalidOperationException("ConnectString must be required!");
            }
            var serverVersion = ServerVersion.AutoDetect(connectionString);

            services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, serverVersion));

            // Repository
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            return services;
        }
    }
}
