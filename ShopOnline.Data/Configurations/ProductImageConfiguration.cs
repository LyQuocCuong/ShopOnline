using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnline.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Data.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<PRODUCT_IMAGE>
    {
        public void Configure(EntityTypeBuilder<PRODUCT_IMAGE> builder)
        {
            builder.ToTable("ProductImage");
            builder.HasKey(proImage => proImage.Id);
            builder.HasOne(proImage => proImage.Product)
                .WithMany(pro => pro.ProductImages)
                .HasForeignKey(proImage => proImage.ProductId);
            builder.Property(proImage => proImage.Path).IsRequired();
            builder.Property(proImage => proImage.CreatedDate).IsRequired();
            builder.Property(proImage => proImage.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
