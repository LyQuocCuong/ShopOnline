using ShopOnline.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class S_ACTION
    {
        public Guid ID { get; set; }
        public string NAME { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public bool IS_DELETED { get; set; }

        //inverse navigation property
        public ICollection<S_PERMISSION> S_PERMISSIONS { get; set; }
    }
}
