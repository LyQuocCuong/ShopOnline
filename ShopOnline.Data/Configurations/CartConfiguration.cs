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
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts"); //Name Table in DB
            builder.HasKey(s => s.Id); //Primary Key
            builder.HasOne(s => s.Product).WithMany(s => s.Carts).HasForeignKey(s => s.ProductId); //Foreign Key: One-to-Many: 1Product - nCart
            builder.Property(s => s.Quantity).IsRequired().HasDefaultValue(0); //Not Null + Default Value
            builder.Property(s => s.Price).IsRequired().HasDefaultValue(0);
            builder.Property(s => s.CreatedDate).IsRequired();
            builder.Property(s => s.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
