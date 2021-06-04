using ShopOnline.Dto.Catalog.Product;
using ShopOnline.Service.Public.IServices;
using System;
using System.Collections.Generic;

namespace ShopOnline.Service.Services
{
    public class PublicProductService : IPublicProductService
    {
        public List<ProductViewDto> GetAll(Guid categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
