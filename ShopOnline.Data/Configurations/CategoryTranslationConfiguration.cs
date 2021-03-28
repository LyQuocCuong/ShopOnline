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
            builder.ToTable("CategoryTranslations");
            builder.HasKey(s => s.Id);
            builder.HasOne(s => s.Category).WithMany(s => s.CategoryTranslations).HasForeignKey(s => s.CategoryId);
            builder.HasOne(s => s.Language).WithMany(s => s.CategoryTranslations).HasForeignKey(s => s.LanguageId);
            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.CreatedDate).IsRequired();
            builder.Property(s => s.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
