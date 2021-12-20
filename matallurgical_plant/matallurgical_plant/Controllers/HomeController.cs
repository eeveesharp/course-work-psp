using matallurgical_plant.Domain;
using matallurgical_plant.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace matallurgical_plant.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productServices;
        private readonly AppDbContext _db;

        public HomeController(
            ILogger<HomeController> logger,
            IProductService productServices)
        {
            _logger = logger;
            _productServices = productServices;

        }

        public IActionResult Index()
        {
            var model = _productServices.GetAll();

            return View(model);
        }

    }
}
