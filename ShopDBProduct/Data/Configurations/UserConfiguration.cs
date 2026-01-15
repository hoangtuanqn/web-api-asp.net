using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopDBProduct.Entities;

namespace ShopDBProduct.Data.Configurations
{
    /*
     * IEntityTypeConfiguration: Khi Implement nó, EF sẽ mặc định đây là nơi chứa các quy tắc cho bảng users trong DB
     *
     */
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Email).IsRequired().IsUnicode(true);
            builder.Property(p => p.Password).IsRequired();
        }
    }
}
