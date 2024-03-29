﻿using ShopOnline.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Models.Catalog.Product
{
    public class ProductUpdateDto
    {
        public Guid Id { get; set; }
        public double OriginalPrice { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int ViewCount { get; set; }
        public ProductStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
