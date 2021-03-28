using ShopOnline.Data.Dtos;
using ShopOnline.Service.Public.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
