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
        public Guid ID { get; set; }
        public double ORIGINAL_PRICE { get; set; }
        public double SELLING_PRICE { get; set; }
        public int STOCK_AMOUNT { get; set; }
        public int VIEW_COUNT { get; set; }
        public ProductStatus STATUS { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public bool IS_DELETED { get; set; }

        //inverse navigation property
        public ICollection<CART> CARTS { get; set; }
        public ICollection<PRODUCT_IN_CATEGORY> PRODUCT_IN_CATEGORIES { get; set; } //Many-To-Many
        public ICollection<ORDER_DETAIL> ORDER_DETAILS { get; set; }
        public ICollection<PRODUCT_TRANSLATION> PRODUCT_TRANSLATIONS { get; set; }
        public ICollection<PRODUCT_IMAGE> PRODUCT_IMAGES { get; set; }
    }
}
