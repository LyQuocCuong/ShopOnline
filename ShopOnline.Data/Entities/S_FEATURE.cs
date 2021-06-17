﻿using ShopOnline.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class S_FEATURE
    {
        public Guid ID { get; set; }
        public Guid? PARENT_ID { get; set; }
        public string NAME { get; set; }
        public string URL { get; set; }
        public string SORT_ORDER { get; set; }
        public SysStatus STATUS { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public bool IS_DELETED { get; set; }

        //inverse navigation property
        public S_FEATURE PARENT_FEATURE { get; set; }
        public ICollection<S_FEATURE> CHILD_FEATURES { get; set; }
        public ICollection<S_PERMISSION> S_PERMISSIONS { get; set; }
    }
}
