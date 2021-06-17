using Microsoft.AspNetCore.Identity;
using ShopOnline.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class S_USER : IdentityUser<Guid>
    {
        public string FULL_NAME { get; set; }
        public DateTime DOB { get; set; }
        public DateTime LAST_LOGIN_DATE { get; set; }
        public UserStatus STATUS { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public bool IS_DELETED { get; set; }

        //inverse navigation property
        public ICollection<ORDER> ORDERS { get; set; }
        public ICollection<S_LOG_ACTIVITY> S_LOG_ACTIVITIES { get; set; }
    }
}
