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
    public class SysFeatureConfiguration : IEntityTypeConfiguration<SYS_FEATURE>
    {
        public void Configure(EntityTypeBuilder<SYS_FEATURE> builder)
        {
            builder.ToTable("SysFeature");
            builder.HasKey(s => s.Id);
            //Self reference association
            builder.HasMany(x => x.ChildrendFeatures).WithOne(x => x.ParentFeature).HasForeignKey(x => x.ParentId);
            builder.Property(s => s.Name).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(s => s.CreatedDate).IsRequired();
            builder.Property(s => s.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
