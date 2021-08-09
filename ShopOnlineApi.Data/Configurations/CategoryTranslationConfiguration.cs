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
    public class CategoryTranslationConfiguration : IEntityTypeConfiguration<CATEGORY_TRANSLATION>
    {
        public void Configure(EntityTypeBuilder<CATEGORY_TRANSLATION> builder)
        {
            builder.ToTable("CATEGORY_TRANSLATION");
            builder.HasKey(s => s.ID);
            builder.HasOne(s => s.CATEGORY).WithMany(s => s.CATEGORY_TRANSLATIONS).HasForeignKey(s => s.CATEGORY_ID);
            builder.HasOne(s => s.LANGUAGE).WithMany(s => s.CATEGORY_TRANSLATIONS).HasForeignKey(s => s.LANGUAGE_ID);
            builder.Property(s => s.NAME).IsRequired();
            builder.Property(s => s.CREATED_DATE).IsRequired();
            builder.Property(s => s.IS_DELETED).IsRequired().HasDefaultValue(false);
        }
    }
}
