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
    public class ProductTranslationConfiguration : IEntityTypeConfiguration<PRODUCT_TRANSLATION>
    {
        public void Configure(EntityTypeBuilder<PRODUCT_TRANSLATION> builder)
        {
            builder.ToTable("PRODUCT_TRANSLATION");
            builder.HasKey(x => x.ID);
            builder.HasOne(x => x.PRODUCT).WithMany(x => x.PRODUCT_TRANSLATIONS).HasForeignKey(x => x.PRODUCT_ID);
            builder.HasOne(x => x.LANGUAGE).WithMany(x => x.PRODUCT_TRANSLATIONS).HasForeignKey(x => x.LANGUAGE_ID);
            builder.Property(x => x.NAME).IsRequired();
            builder.Property(s => s.CREATED_DATE).IsRequired();
            builder.Property(s => s.IS_DELETED).IsRequired().HasDefaultValue(false);
        }
    }
}
