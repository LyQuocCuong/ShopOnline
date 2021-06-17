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
    public class SysUserConfiguration : IEntityTypeConfiguration<S_USER>
    {
        public void Configure(EntityTypeBuilder<S_USER> builder)
        {
            builder.ToTable("S_USER");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.FULL_NAME).IsRequired();
            builder.Property(x => x.STATUS).IsRequired();
            builder.Property(x => x.LAST_LOGIN_DATE).IsRequired();
            builder.Property(s => s.CREATED_DATE).IsRequired();
            builder.Property(s => s.IS_DELETED).IsRequired().HasDefaultValue(false);
        }
    }
}
