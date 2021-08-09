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
    public class CartConfiguration : IEntityTypeConfiguration<CART>
    {
        public void Configure(EntityTypeBuilder<CART> builder)
        {
            builder.ToTable("CART"); //Name Table in DB
            builder.HasKey(s => s.ID); //Primary Key
            builder.HasOne(s => s.PRODUCT).WithMany(s => s.CARTS).HasForeignKey(s => s.PRODUCT_ID); //Foreign Key: One-to-Many: 1Product - nCart
            builder.Property(s => s.QUANTITY).IsRequired().HasDefaultValue(0); //Not Null + Default Value
            builder.Property(s => s.PRICE).IsRequired().HasDefaultValue(0);
            builder.Property(s => s.CREATED_DATE).IsRequired();
            builder.Property(s => s.IS_DELETED).IsRequired().HasDefaultValue(false);
        }
    }
}
