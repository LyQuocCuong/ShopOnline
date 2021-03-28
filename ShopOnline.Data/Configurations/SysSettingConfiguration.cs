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
    public class SysSettingConfiguration : IEntityTypeConfiguration<SYS_SETTING>
    {
        public void Configure(EntityTypeBuilder<SYS_SETTING> builder)
        {
            builder.ToTable("SysSettings");
            builder.HasKey(s => s.Key);
            builder.Property(s => s.Value).IsRequired();
            builder.Property(s => s.CreatedDate).IsRequired();
            builder.Property(s => s.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
