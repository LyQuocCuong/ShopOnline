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
            builder.ToTable("Categories");
            builder.HasKey(s => s.Id);
            //Self reference association
            builder.HasMany(s => s.ChildrenCategories).WithOne(s => s.ParentCategory).HasForeignKey(s => s.ParentId);
            builder.Property(s => s.SortOrder).IsRequired();
            builder.Property(s => s.IsShowOnHome).IsRequired();
            builder.Property(s => s.Status).IsRequired();
            builder.Property(s => s.CreatedDate).IsRequired();
            builder.Property(s => s.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
