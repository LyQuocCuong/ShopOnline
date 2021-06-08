using Microsoft.AspNetCore.Mvc;
using ShopOnline.Service.Public.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IPublicProductService _publicProductService;

        public ProductController(IPublicProductService publicProductService)
        {
            _publicProductService = publicProductService;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok(_publicProductService.GetAll(Guid.NewGuid()));
        }
    }
}
