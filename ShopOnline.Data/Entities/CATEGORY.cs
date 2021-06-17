using ShopOnline.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class CATEGORY
    {
        public Guid ID { get; set; }
        public Guid? PARENT_ID { get; set; }
        public int SORT_ORDER { get; set; }
        public bool IS_SHOW_ON_HOME { get; set; }
        public SysStatus STATUS { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public bool IS_DELETED { get; set; }

        //INVERSE NAVIGATION PROPERTY
        public ICollection<PRODUCT_IN_CATEGORY> PRODUCT_IN_CATEGORIES { get; set; } //Many-To-Many
        public ICollection<CATEGORY_TRANSLATION> CATEGORY_TRANSLATIONS { get; set; }

        #region SELF REFERENCE ASSOCIATION
        public CATEGORY PARENT_CATEGORY { get; set; }
        public ICollection<CATEGORY> CHILD_CATEGORIES { get; set; }
        #endregion
    }
}
