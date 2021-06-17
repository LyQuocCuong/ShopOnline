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
    public class SysRoleConfiguration : IEntityTypeConfiguration<S_ROLE>
    {
        public void Configure(EntityTypeBuilder<S_ROLE> builder)
        {
            builder.ToTable("S_ROLE");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.DESCRIPTION);
            builder.Property(s => s.CREATED_DATE).IsRequired();
            builder.Property(s => s.IS_DELETED).IsRequired().HasDefaultValue(false);
        }
    }
}
