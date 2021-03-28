using ShopOnline.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Service.Private.IServices
{
    public interface IPrivateProductService
    {
        bool Create(ProductCreateDto productCreateDto);
        bool Update(ProductUpdateDto productUpdateDto);
        bool Delete(Guid productId);
    }
}
