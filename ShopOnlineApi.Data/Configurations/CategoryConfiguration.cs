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
    public class CategoryConfiguration : IEntityTypeConfiguration<CATEGORY>
    {
        public void Configure(EntityTypeBuilder<CATEGORY> builder)
        {
            builder.ToTable("CATEGORY");
            builder.HasKey(s => s.ID);
            //Self reference association
            builder.HasMany(s => s.CHILD_CATEGORIES).WithOne(s => s.PARENT_CATEGORY).HasForeignKey(s => s.PARENT_ID);
            builder.Property(s => s.SORT_ORDER).IsRequired();
            builder.Property(s => s.IS_SHOW_ON_HOME).IsRequired();
            builder.Property(s => s.STATUS).IsRequired();
            builder.Property(s => s.CREATED_DATE).IsRequired();
            builder.Property(s => s.IS_DELETED).IsRequired().HasDefaultValue(false);
        }
    }
}
