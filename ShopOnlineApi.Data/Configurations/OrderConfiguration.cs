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
    public class OrderConfiguration : IEntityTypeConfiguration<ORDER>
    {
        public void Configure(EntityTypeBuilder<ORDER> builder)
        {
            builder.ToTable("ORDER");
            builder.HasKey(s => s.ID);
            builder.HasOne(s => s.S_USER).WithMany(s => s.ORDERS).HasForeignKey(s => s.S_USER_ID);
            builder.Property(s => s.ORDER_DATE).IsRequired();
            builder.Property(s => s.SHIP_ADDRESS).IsRequired();
            builder.Property(s => s.STATUS).IsRequired();
            builder.Property(s => s.CREATED_DATE).IsRequired();
            builder.Property(s => s.IS_DELETED).IsRequired().HasDefaultValue(false);
        }
    }
}
