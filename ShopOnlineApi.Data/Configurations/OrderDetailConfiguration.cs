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
    public class OrderDetailConfiguration : IEntityTypeConfiguration<ORDER_DETAIL>
    {
        public void Configure(EntityTypeBuilder<ORDER_DETAIL> builder)
        {
            builder.ToTable("ORDER_DETAIL");
            builder.HasKey(x => x.ID);
            builder.HasOne(x => x.ORDER).WithMany(x => x.ORDER_DETAILS).HasForeignKey(x => x.ORDER_ID);
            builder.HasOne(x => x.PRODUCT).WithMany(x => x.ORDER_DETAILS).HasForeignKey(x => x.PRODUCT_ID);
            builder.Property(s => s.QUANTITY).IsRequired();
            builder.Property(s => s.PRICE).IsRequired();
            builder.Property(s => s.CREATED_DATE).IsRequired();
            builder.Property(s => s.IS_DELETED).IsRequired().HasDefaultValue(false);
        }
    }
}
