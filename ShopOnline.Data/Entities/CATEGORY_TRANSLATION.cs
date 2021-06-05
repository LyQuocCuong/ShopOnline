using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class CATEGORY_TRANSLATION
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string SeoAlias { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        //inverse navigation property
        public CATEGORY Category { get; set; }
        public LANGUAGE Language { get; set; }
    }
}
