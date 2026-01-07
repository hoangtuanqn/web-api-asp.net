using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopDBProduct.Entities;

namespace ShopDBProduct.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .ToTable("products")
                .HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Image).IsRequired(false).HasMaxLength(255); // cho phép NULL
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            // Cấu hình quan hệ
            // Đứng ở phía product thì nói là:
            builder
                .HasOne(p => p.Category) // mỗi product chỉ có 1 cái category
                .WithMany(p => p.Products) // còn cái này nói là: 1 category thì có nhiều sp
                .HasForeignKey(p => p.CategoryId) // khóa ngoại là cái nào?
                .OnDelete(DeleteBehavior.Restrict); // ko cho xóa cái danh mục nếu đang có sp trong đó
        }
    }
}
