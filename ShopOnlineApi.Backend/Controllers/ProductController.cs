using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopOnline.Service.Public.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ILogger _logger;
        private readonly IPublicProductService _publicProductService;

        public ProductController(ILogger<ProductController> logger, IPublicProductService publicProductService)
        {
            _logger = logger;
            _publicProductService = publicProductService;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            _logger.LogInformation("Hello");
            return Ok(_publicProductService.GetAll(Guid.NewGuid()));
        }
    }
}
