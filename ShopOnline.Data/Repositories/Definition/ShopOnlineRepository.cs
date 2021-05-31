using ShopOnline.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Repositories.Definition
{
    public class ShopOnlineRepository : IDisposable
    {
        public ShopOnlineDBContext _context;

        public ShopOnlineRepository(ShopOnlineDBContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private ProductRepository productRepository { get; set; }
        public ProductRepository PRODUCT_REPOSITORY
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(this);
                return productRepository;
            }
        }


    }
}
