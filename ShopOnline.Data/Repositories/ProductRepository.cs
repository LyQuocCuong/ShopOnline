using ShopOnline.Data.Dtos;
using ShopOnline.Data.Entities;
using ShopOnline.Data.Enums;
using ShopOnline.Data.Repositories.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Repositories
{
    public class ProductRepository : AbstractRepository<PRODUCT>
    {
        public ProductRepository(ShopOnlineRepository repository): base(repository)
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
