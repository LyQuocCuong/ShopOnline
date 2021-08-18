using ShopOnline.Data.Entities;
using ShopOnline.Data.Enums;
using ShopOnline.Data.Repositories.Definition;
using ShopOnline.Models.Catalog.Product;
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
                ID = productDto.Id,
                ORIGINAL_PRICE = productDto.OriginalPrice,
                SELLING_PRICE = productDto.Price,
                STOCK_AMOUNT = productDto.Stock,
                VIEW_COUNT = 0,
                CREATED_DATE = DateTime.Now,
                STATUS = ProductStatus.InStock,
                IS_DELETED = false,
            };
            DataSet.Add(newProduct);
            return true;
        }
    }
}
