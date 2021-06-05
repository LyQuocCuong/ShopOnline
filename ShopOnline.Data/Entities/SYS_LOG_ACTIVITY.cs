using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class SYS_LOG_ACTIVITY
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ClientId { get; set; }
        public string SysFeatureName { get; set; }
        public string SysActionName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        //inverse navigation property
        public SYS_USER SysUser { get; set; }
    }
}
