using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class SysPermission
    {
        public Guid Id { get; set; }
        public Guid SysRoleId { get; set; }
        public Guid SysFeatureId { get; set; }
        public Guid SysActionId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        //inverse navigation property
        public SysRole SysRole { get; set; }
        public SysFeature SysFeature { get; set; }
        public SysAction SysAction { get; set; }
    }
}
