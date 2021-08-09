using ShopOnline.Dto.Catalog.Product;
using System;

namespace ShopOnline.Service.Private.IServices
{
    public interface IPrivateProductService
    {
        bool Create(ProductCreateDto productCreateDto);
        bool Update(ProductUpdateDto productUpdateDto);
        bool Delete(Guid productId);
    }
}
