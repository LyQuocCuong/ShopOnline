using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ShopOnline.Data.Entities
{
    public class PRODUCT_IMAGE
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Caption { get; set; }
        public string Path { get; set; }
        public int SortOrder { get; set; }
        public bool IsDefault { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public PRODUCT Product { get; set; }
    }
}