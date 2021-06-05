using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class PRODUCT_IN_CATEGORY
    {
        public Guid CategoryId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        //inverse navigation property
        public CATEGORY Category { get; set; }
        public PRODUCT Product { get; set; }
    }
}
