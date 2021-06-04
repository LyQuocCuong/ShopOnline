using ShopOnline.Data.Entities;
using ShopOnline.Data.Enums;
using ShopOnline.Data.Repositories.Definition;
using ShopOnline.Dto.Catalog.Product;
using System;

namespace ShopOnline.Data.Repositories
{
    public class ProductRepository : AbstractRepository<PRODUCT>
    {
        public ProductRepository(ShopOnlineRepository repository) : base(repository)
        {

        }

        public bool CreateProduct(ProductCreateDto productDto)
        {
            productDto.Id = Guid.NewGuid();
            PRODUCT newProduct = new PRODUCT()
            {
                Id = productDto.Id,
                OriginalPrice = productDto.OriginalPrice,
                Price = productDto.Price,
                Stock = productDto.Stock,
                ViewCount = 0,
                CreatedDate = DateTime.Now,
                Status = ProductStatus.InStock,
                IsDeleted = false,
            };
            DataSet.Add(newProduct);
            return true;
        }
    }
}
