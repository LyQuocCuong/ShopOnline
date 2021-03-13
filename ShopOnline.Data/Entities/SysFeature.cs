using ShopOnline.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class SysFeature
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
        public SysFeature ParentFeature { get; set; }
        public ICollection<SysFeature> ChildrendFeatures { get; set; }
        public ICollection<SysPermission> SysPermissions { get; set; }
    }
}
