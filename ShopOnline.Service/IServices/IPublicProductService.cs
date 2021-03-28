using ShopOnline.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Service.Public.IServices
{
    public interface IPublicProductService
    {
        List<ProductViewDto> GetAll(Guid categoryId);
    }
}
