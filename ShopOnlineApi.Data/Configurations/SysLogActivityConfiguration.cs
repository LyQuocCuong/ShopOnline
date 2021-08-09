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
    public class SysLogActivityConfiguration : IEntityTypeConfiguration<S_LOG_ACTIVITY>
    {
        public void Configure(EntityTypeBuilder<S_LOG_ACTIVITY> builder)
        {
            builder.ToTable("S_LOG_ACTIVITY");
            builder.HasKey(x => x.ID);
            builder.HasOne(x => x.S_USER).WithMany(x => x.S_LOG_ACTIVITIES).HasForeignKey(x => x.S_USER_ID);
            builder.Property(x => x.CLIENT_ID).IsRequired();
            builder.Property(x => x.S_FEATURE_NAME).IsRequired();
            builder.Property(x => x.S_ACTION_NAME).IsRequired();
            builder.Property(s => s.CREATED_DATE).IsRequired();
            builder.Property(s => s.IS_DELETED).IsRequired().HasDefaultValue(false);
        }
    }
}
