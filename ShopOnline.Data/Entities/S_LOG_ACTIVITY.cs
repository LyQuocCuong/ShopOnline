using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class S_LOG_ACTIVITY
    {
        public Guid ID { get; set; }
        public Guid S_USER_ID { get; set; }
        public Guid CLIENT_ID { get; set; }
        public string S_FEATURE_NAME { get; set; }
        public string S_ACTION_NAME { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public bool IS_DELETED { get; set; }

        //inverse navigation property
        public S_USER S_USER { get; set; }
    }
}
