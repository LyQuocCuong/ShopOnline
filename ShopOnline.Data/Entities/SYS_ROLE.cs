using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class SYS_ROLE : IdentityRole<Guid>
    {
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        //inverse navigation property
        public ICollection<SYS_PERMISSION> SysPermissions { get; set; }
    }
}
