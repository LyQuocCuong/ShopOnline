using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopOnline.Dto.Catalog.Product;
using ShopOnline.GUI.Models;
using ShopOnline.Service.Private.IServices;
using System.Diagnostics;

namespace ShopOnline.GUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPrivateProductService _privateProductService;

        public HomeController(ILogger<HomeController> logger, IPrivateProductService privateProductService)
        {
            _logger = logger;
            _privateProductService = privateProductService;
        }

        public IActionResult Index()
        {
            ViewBag.Result = _privateProductService.Create(new ProductCreateDto());
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
