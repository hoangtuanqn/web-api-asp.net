using Microsoft.EntityFrameworkCore;
using ShopDBProduct.Entities;
using ShopDBProduct.Utils;

namespace ShopDBProduct.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Chuyển thành chữ thường
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // table name
                entity.SetTableName(Helpers.ConvertSnakeCase(entity.GetTableName()!));

                // column name
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(Helpers.ConvertSnakeCase(property.GetColumnName()));
                }

                // FK, Index, Key
                foreach (var key in entity.GetKeys())
                {
                    key.SetName(Helpers.ConvertSnakeCase(key.GetName()!));
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.SetDatabaseName(Helpers.ConvertSnakeCase(index.GetDatabaseName()!));
                }

            }

        }
    }
}
