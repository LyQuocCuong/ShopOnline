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
            builder.ToTable("ProductInCategory");
            builder.HasKey(s => new { s.CategoryId, s.ProductId });
            builder.HasOne(s => s.Product).WithMany(s => s.ProductInCategories).HasForeignKey(s => s.ProductId);
            builder.HasOne(s => s.Category).WithMany(s => s.ProductInCategories).HasForeignKey(s => s.CategoryId);
            builder.Property(s => s.CreatedDate).IsRequired();
            builder.Property(s => s.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
