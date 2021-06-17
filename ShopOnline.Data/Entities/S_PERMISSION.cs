using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class S_PERMISSION
    {
        public Guid ID { get; set; }
        public Guid S_ROLE_ID { get; set; }
        public Guid S_FEATURE_ID { get; set; }
        public Guid S_ACTION_ID { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public bool IS_DELETED { get; set; }

        //inverse navigation property
        public S_ROLE S_ROLE { get; set; }
        public S_FEATURE S_FEATURE { get; set; }
        public S_ACTION S_ACTION { get; set; }
    }
}
