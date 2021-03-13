using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class ProductInCategory
    {
        public Guid CategoryId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        //inverse navigation property
        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}
