using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class ORDER_DETAIL
    {
        public Guid ID { get; set; }
        public Guid ORDER_ID { get; set; }
        public Guid PRODUCT_ID { get; set; }
        public int QUANTITY { get; set; }
        public double PRICE { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public bool IS_DELETED { get; set; }

        //inverse navigation property
        public ORDER ORDER { get; set; }
        public PRODUCT PRODUCT { get; set; }
    }
}
