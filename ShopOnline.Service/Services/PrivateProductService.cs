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
        private readonly ShopOnlineRepository _shopOnline;

        public PrivateProductService(ShopOnlineRepository shopOnline)
        {
            _shopOnline = shopOnline;
        }

        public bool Create(ProductCreateDto productCreateDto)
        {
            try
            {
                _shopOnline.PRODUCT_REPOSITORY.CreateProduct(productCreateDto);
                _shopOnline.SaveChanges();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
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
