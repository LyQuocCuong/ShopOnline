﻿using ShopOnline.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public int SortOrder { get; set; }
        public bool IsShowOnHome { get; set; }
        public SysStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        //inverse navigation property
        public ICollection<ProductInCategory> ProductInCategories { get; set; } //Many-To-Many
        public ICollection<CategoryTranslation> CategoryTranslations { get; set; }
        
        #region Self reference association
        public Category ParentCategory { get; set; }
        public ICollection<Category> ChildrenCategories { get; set; }
        #endregion
    }
}
