using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class LANGUAGE
    {
        public Guid ID { get; set; }
        public string NAME { get; set; }
        public bool IS_DEFAULT { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public bool IS_DELETED { get; set; }

        //inverse navigation property
        public ICollection<CATEGORY_TRANSLATION> CATEGORY_TRANSLATIONS { get; set; }
        public ICollection<PRODUCT_TRANSLATION> PRODUCT_TRANSLATIONS { get; set; }
    }
}
