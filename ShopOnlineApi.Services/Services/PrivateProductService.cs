using ShopOnline.Data.Repositories.Definition;
using ShopOnline.Models.Catalog.Product;
using ShopOnline.Service.Private.IServices;
using System;

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
