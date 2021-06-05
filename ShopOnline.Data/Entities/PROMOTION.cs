using ShopOnline.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class PROMOTION
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public double DiscountPercent { get; set; }
        public double DiscountAmount { get; set; }
        public bool IsApplyForAll { get; set; }
        public string AppliedProductIds { get; set; }
        public SysStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
