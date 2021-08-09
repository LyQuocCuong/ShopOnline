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
    public class ContactConfiguration : IEntityTypeConfiguration<CONTACT>
    {
        public void Configure(EntityTypeBuilder<CONTACT> builder)
        {
            builder.ToTable("CONTACT");
            builder.HasKey(s => s.ID);
            builder.Property(s => s.NAME).IsRequired();
            builder.Property(s => s.STATUS).IsRequired();
            builder.Property(s => s.CREATED_DATE).IsRequired();
            builder.Property(s => s.IS_DELETED).IsRequired().HasDefaultValue(false);
        }
    }
}
