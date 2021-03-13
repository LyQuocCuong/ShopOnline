using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class UserRole
    {
        public Guid UserId { get; set; }
        public Guid SysRoleId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        //inverse navigation property
        public User User { get; set; }
        public SysRole SysRole { get; set; }
    }
}
