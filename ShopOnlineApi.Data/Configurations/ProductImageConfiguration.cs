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
            builder.ToTable("PRODUCT_IMAGE");
            builder.HasKey(proImage => proImage.ID);
            builder.HasOne(proImage => proImage.PRODUCT)
                .WithMany(pro => pro.PRODUCT_IMAGES)
                .HasForeignKey(proImage => proImage.PRODUCT_ID);
            builder.Property(proImage => proImage.PATH).IsRequired();
            builder.Property(proImage => proImage.CREATED_DATE).IsRequired();
            builder.Property(proImage => proImage.IS_DELETED).IsRequired().HasDefaultValue(false);
        }
    }
}
