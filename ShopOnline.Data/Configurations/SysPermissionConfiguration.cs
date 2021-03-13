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
    public class SysPermissionConfiguration : IEntityTypeConfiguration<SysPermission>
    {
        public void Configure(EntityTypeBuilder<SysPermission> builder)
        {
            builder.ToTable("SysPermissions");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.SysRole).WithMany(x => x.SysPermissions).HasForeignKey(x => x.SysRoleId);
            builder.HasOne(x => x.SysFeature).WithMany(x => x.SysPermissions).HasForeignKey(x => x.SysFeatureId);
            builder.HasOne(x => x.SysAction).WithMany(x => x.SysPermissions).HasForeignKey(x => x.SysActionId);
            builder.Property(s => s.CreatedDate).IsRequired();
            builder.Property(s => s.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
