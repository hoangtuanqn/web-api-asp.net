using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopDBProduct.Entities;

namespace ShopDBProduct.Services
{
    public class CategoryService : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categories").HasKey(p => p.Id);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(255);
            builder.Property(c => c.Description).IsRequired().HasMaxLength(255);
            builder.Property(c => c.Status).IsRequired(false).HasDefaultValue(false);
            builder
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
