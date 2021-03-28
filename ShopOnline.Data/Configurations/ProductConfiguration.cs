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
            builder.ToTable("Products");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.OriginalPrice).IsRequired();
            builder.Property(s => s.Price).IsRequired();
            builder.Property(s => s.Stock).IsRequired();
            builder.Property(s => s.ViewCount).IsRequired();
            builder.Property(s => s.Status).IsRequired();
            builder.Property(s => s.CreatedDate).IsRequired();
            builder.Property(s => s.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
