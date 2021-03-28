using ShopOnline.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class SYS_FEATURE
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string SortOrder { get; set; }
        public SysStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        //inverse navigation property
        public SYS_FEATURE ParentFeature { get; set; }
        public ICollection<SYS_FEATURE> ChildrendFeatures { get; set; }
        public ICollection<SYS_PERMISSION> SysPermissions { get; set; }
    }
}
