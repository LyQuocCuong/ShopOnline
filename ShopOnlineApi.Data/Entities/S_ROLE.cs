using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class S_ROLE : IdentityRole<Guid>
    {
        public string DESCRIPTION { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public bool IS_DELETED { get; set; }

        //inverse navigation property
        public ICollection<S_PERMISSION> S_PERMISSIONS { get; set; }
    }
}
