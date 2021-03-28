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
    public class SysLogActivityConfiguration : IEntityTypeConfiguration<SysLogActivity>
    {
        public void Configure(EntityTypeBuilder<SysLogActivity> builder)
        {
            builder.ToTable("SysLogActivities");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.SysUser).WithMany(x => x.SysLogActivities).HasForeignKey(x => x.UserId);
            builder.Property(x => x.SysFeatureName).IsRequired();
            builder.Property(x => x.SysFeatureName).IsRequired();
            builder.Property(s => s.CreatedDate).IsRequired();
            builder.Property(s => s.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
