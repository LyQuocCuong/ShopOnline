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
    public class SysPermissionConfiguration : IEntityTypeConfiguration<S_PERMISSION>
    {
        public void Configure(EntityTypeBuilder<S_PERMISSION> builder)
        {
            builder.ToTable("S_PERMISSION");
            builder.HasKey(x => x.ID);
            builder.HasOne(x => x.S_ROLE).WithMany(x => x.S_PERMISSIONS).HasForeignKey(x => x.S_ROLE_ID);
            builder.HasOne(x => x.S_FEATURE).WithMany(x => x.S_PERMISSIONS).HasForeignKey(x => x.S_FEATURE_ID);
            builder.HasOne(x => x.S_ACTION).WithMany(x => x.S_PERMISSIONS).HasForeignKey(x => x.S_ACTION_ID);
            builder.Property(s => s.CREATED_DATE).IsRequired();
            builder.Property(s => s.IS_DELETED).IsRequired().HasDefaultValue(false);
        }
    }
}
