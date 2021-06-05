using Microsoft.AspNetCore.Identity;
using ShopOnline.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class SYS_USER : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public DateTime LastLoginDate { get; set; }
        public UserStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        //inverse navigation property
        public ICollection<ORDER> Orders { get; set; }
        public ICollection<SYS_LOG_ACTIVITY> SysLogActivities { get; set; }
    }
}
