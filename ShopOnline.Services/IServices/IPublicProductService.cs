using ShopOnline.Dto.Catalog.Product;
using System;
using System.Collections.Generic;

namespace ShopOnline.Service.Public.IServices
{
    public interface IPublicProductService
    {
        List<ProductViewDto> GetAll(Guid categoryId);
    }
}
