using ShopOnline.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public double OriginalPrice { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int ViewCount { get; set; }
        public ProductStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        //inverse navigation property
        public ICollection<Cart> Carts { get; set; }
        public ICollection<ProductInCategory> ProductInCategories { get; set; } //Many-To-Many
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<ProductTranslation> ProductTranslations { get; set; }
    }
}
