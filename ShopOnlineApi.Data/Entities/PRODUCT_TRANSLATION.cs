using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class PRODUCT_TRANSLATION
    {
        public Guid ID { get; set; }
        public Guid PRODUCT_ID { get; set; }
        public Guid LANGUAGE_ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string DETAILS { get; set; }
        public string SEO_DESCRIPTION { get; set; }
        public string SEO_TITLE { get; set; }
        public string SEO_ALIAS { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public bool IS_DELETED { get; set; }

        //inverse navigation property
        public PRODUCT PRODUCT { get; set; }
        public LANGUAGE LANGUAGE { get; set; }
    }
}
