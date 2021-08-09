using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ShopOnline.Data.Entities
{
    public class PRODUCT_IMAGE
    {
        public Guid ID { get; set; }
        public Guid PRODUCT_ID { get; set; }
        public string CAPTION { get; set; }
        public string PATH { get; set; }
        public int SORT_ORDER { get; set; }
        public bool IS_DEFAULT { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public bool IS_DELETED { get; set; }

        public PRODUCT PRODUCT { get; set; }
    }
}