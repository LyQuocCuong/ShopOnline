using ShopOnline.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class ORDER
    {
        public Guid ID { get; set; }
        public Guid S_USER_ID { get; set; }
        public DateTime ORDER_DATE { get; set; }
        public string SHIP_NAME { get; set; }
        public string SHIP_ADDRESS { get; set; }
        public string SHIP_EMAIL { get; set; }
        public string SHIP_PHONE_NUMBER { get; set; }
        public OrderStatus STATUS { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public bool IS_DELETED { get; set; }

        //inverse navigation property
        public S_USER S_USER { get; set; }
        public ICollection<ORDER_DETAIL> ORDER_DETAILS { get; set; }
    }
}
