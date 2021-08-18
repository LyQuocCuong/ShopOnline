using ShopOnline.Models.Catalog.Product;
using ShopOnline.Service.Public.IServices;
using System;
using System.Collections.Generic;

namespace ShopOnline.Service.Services
{
    public class PublicProductService : IPublicProductService
    {
        public List<ProductViewDto> GetAll(Guid categoryId)
        {
            return new List<ProductViewDto>();
        }
    }
}
