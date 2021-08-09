using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class PRODUCT_IN_CATEGORY
    {
        public Guid CATEGORY_ID { get; set; }
        public Guid PRODUCT_ID { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public bool IS_DELETED { get; set; }

        //inverse navigation property
        public CATEGORY CATEGORY { get; set; }
        public PRODUCT PRODUCT { get; set; }
    }
}
