using ShopOnline.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class PROMOTION
    {
        public Guid ID { get; set; }
        public string NAME { get; set; }
        public DateTime FROM_DATE { get; set; }
        public DateTime TO_DATE { get; set; }
        public double DISCOUNT_PERCENT { get; set; }
        public double DISCOUNT_AMOUNT { get; set; }
        public bool IS_APPLY_FOR_ALL { get; set; }
        public string APPLIED_PRODUCTIDS { get; set; }
        public SysStatus STATUS { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public bool IS_DELETED { get; set; }
    }
}
