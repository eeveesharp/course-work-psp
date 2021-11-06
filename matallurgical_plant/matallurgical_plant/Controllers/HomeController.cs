using matallurgical_plant.Models;
using matallurgical_plant.Services;
using matallurgical_plant.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace matallurgical_plant.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productServices;

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

        public IActionResult List()
        {
            var item = _productServices.GetAll();

            return View(item);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _productServices.Delete(id);

            return RedirectToAction("Index");
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

        [HttpPost]
        public IActionResult Edit(int id,Product model)
        {
            _productServices.Edit(id, model);

            return View("EditProduct");
        }
    }
}
