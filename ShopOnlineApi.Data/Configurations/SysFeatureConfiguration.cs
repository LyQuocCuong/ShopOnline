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
    public class SysFeatureConfiguration : IEntityTypeConfiguration<S_FEATURE>
    {
        public void Configure(EntityTypeBuilder<S_FEATURE> builder)
        {
            builder.ToTable("S_FEATURE");
            builder.HasKey(s => s.ID);
            //Self reference association
            builder.HasMany(x => x.CHILD_FEATURES).WithOne(x => x.PARENT_FEATURE).HasForeignKey(x => x.PARENT_ID);
            builder.Property(s => s.NAME).IsRequired();
            builder.Property(x => x.STATUS).IsRequired();
            builder.Property(s => s.CREATED_DATE).IsRequired();
            builder.Property(s => s.IS_DELETED).IsRequired().HasDefaultValue(false);
        }
    }
}
