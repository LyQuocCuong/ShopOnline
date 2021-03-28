using ShopOnline.Data.Dtos;
using ShopOnline.Data.Entities;
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
            PRODUCT newProduct = new PRODUCT()
            {

            };
            DataSet.Add(newProduct);
            return true;
        }
    }
}
