using Microsoft.EntityFrameworkCore;
using ShopDBProduct.Entities;

namespace ShopDBProduct.Data
{
    public class AppDbContext: DbContext
    {

        public  AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        public DbSet<Category> Category {  get; set; }
        public DbSet<Product> Products {  get; set; }
    }
}
