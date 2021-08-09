using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnline.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Configurations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<PRODUCT_IN_CATEGORY>
    {
        public void Configure(EntityTypeBuilder<PRODUCT_IN_CATEGORY> builder)
        {
            builder.ToTable("PRODUCT_IN_CATEGORY");
            builder.HasKey(s => new { s.CATEGORY_ID, s.PRODUCT_ID });
            builder.HasOne(s => s.PRODUCT).WithMany(s => s.PRODUCT_IN_CATEGORIES).HasForeignKey(s => s.PRODUCT_ID);
            builder.HasOne(s => s.CATEGORY).WithMany(s => s.PRODUCT_IN_CATEGORIES).HasForeignKey(s => s.CATEGORY_ID);
            builder.Property(s => s.CREATED_DATE).IsRequired();
            builder.Property(s => s.IS_DELETED).IsRequired().HasDefaultValue(false);
        }
    }
}
