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
    public class LanguageConfiguration : IEntityTypeConfiguration<LANGUAGE>
    {
        public void Configure(EntityTypeBuilder<LANGUAGE> builder)
        {
            builder.ToTable("LANGUAGE");
            builder.HasKey(s => s.ID);
            builder.Property(s => s.NAME).IsRequired();
            builder.Property(s => s.IS_DEFAULT).IsRequired().HasDefaultValue(true);
            builder.Property(s => s.CREATED_DATE).IsRequired();
            builder.Property(s => s.IS_DELETED).IsRequired().HasDefaultValue(false);
        }
    }
}
