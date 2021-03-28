using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class LANGUAGE
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        //inverse navigation property
        public ICollection<CATEGORY_TRANSLATION> CategoryTranslations { get; set; }
        public ICollection<PRODUCT_TRANSLATION> ProductTranslations { get; set; }
    }
}
