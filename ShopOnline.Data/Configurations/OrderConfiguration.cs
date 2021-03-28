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
            builder.ToTable("Orders");
            builder.HasKey(s => s.Id);
            builder.HasOne(s => s.SysUser).WithMany(s => s.Orders).HasForeignKey(s => s.UserId);
            builder.Property(s => s.OrderDate).IsRequired();
            builder.Property(s => s.ShipAddress).IsRequired();
            builder.Property(s => s.Status).IsRequired();
            builder.Property(s => s.CreatedDate).IsRequired();
            builder.Property(s => s.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
