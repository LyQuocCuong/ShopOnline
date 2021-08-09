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
    public class SysSettingConfiguration : IEntityTypeConfiguration<S_SETTING>
    {
        public void Configure(EntityTypeBuilder<S_SETTING> builder)
        {
            builder.ToTable("S_SETTING");
            builder.HasKey(s => s.KEY);
            builder.Property(s => s.VALUE).IsRequired();
            builder.Property(s => s.CREATED_DATE).IsRequired();
            builder.Property(s => s.IS_DELETED).IsRequired().HasDefaultValue(false);
        }
    }
}
