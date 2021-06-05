using ShopOnline.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class PRODUCT
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
        public ICollection<CART> Carts { get; set; }
        public ICollection<PRODUCT_IN_CATEGORY> ProductInCategories { get; set; } //Many-To-Many
        public ICollection<ORDER_DETAIL> OrderDetails { get; set; }
        public ICollection<PRODUCT_TRANSLATION> ProductTranslations { get; set; }
        public ICollection<PRODUCT_IMAGE> ProductImages { get; set; }
    }
}
