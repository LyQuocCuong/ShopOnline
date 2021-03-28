using ShopOnline.Data.Dtos;
using ShopOnline.Data.Repositories.Definition;
using ShopOnline.Service.Private.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Service.Private.Services
{
    public class PrivateProductService : IPrivateProductService
    {
        public bool Create(ProductCreateDto productCreateDto)
        {
            using (ShopOnlineRepository repo = new ShopOnlineRepository())
            {
                if (repo.PRODUCT_REPOSITORY.CreateProduct(productCreateDto))
                {
                    repo.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool Delete(Guid productId)
        {
            throw new NotImplementedException();
        }

        public bool Update(ProductUpdateDto productUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
