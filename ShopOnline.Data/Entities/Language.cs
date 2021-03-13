﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class Language
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        //inverse navigation property
        public ICollection<CategoryTranslation> CategoryTranslations { get; set; }
        public ICollection<ProductTranslation> ProductTranslations { get; set; }
    }
}
