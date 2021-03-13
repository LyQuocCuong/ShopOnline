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
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.HasKey(s => new { s.CategoryId, s.ProductId });
            builder.HasOne(s => s.Product).WithMany(s => s.ProductInCategories).HasForeignKey(s => s.ProductId);
            builder.HasOne(s => s.Category).WithMany(s => s.ProductInCategories).HasForeignKey(s => s.CategoryId);
            builder.Property(s => s.CreatedDate).IsRequired();
            builder.Property(s => s.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
