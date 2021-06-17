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
    public class ProductConfiguration : IEntityTypeConfiguration<PRODUCT>
    {
        public void Configure(EntityTypeBuilder<PRODUCT> builder)
        {
            builder.ToTable("PRODUCT");
            builder.HasKey(s => s.ID);
            builder.Property(s => s.ORIGINAL_PRICE).IsRequired();
            builder.Property(s => s.SELLING_PRICE).IsRequired();
            builder.Property(s => s.STOCK_AMOUNT).IsRequired();
            builder.Property(s => s.VIEW_COUNT).IsRequired();
            builder.Property(s => s.STATUS).IsRequired();
            builder.Property(s => s.CREATED_DATE).IsRequired();
            builder.Property(s => s.IS_DELETED).IsRequired().HasDefaultValue(false);
        }
    }
}
