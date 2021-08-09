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
    public class PromotionConfiguration : IEntityTypeConfiguration<PROMOTION>
    {
        public void Configure(EntityTypeBuilder<PROMOTION> builder)
        {
            builder.ToTable("PROMOTION");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.FROM_DATE).IsRequired();
            builder.Property(x => x.TO_DATE).IsRequired();
            builder.Property(x => x.STATUS).IsRequired();
            builder.Property(s => s.CREATED_DATE).IsRequired();
            builder.Property(s => s.IS_DELETED).IsRequired().HasDefaultValue(false);
        }
    }
}
