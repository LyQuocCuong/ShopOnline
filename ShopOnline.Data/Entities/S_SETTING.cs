using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class S_SETTING
    {
        public string KEY { get; set; }
        public string VALUE { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public bool IS_DELETED { get; set; }
    }
}
