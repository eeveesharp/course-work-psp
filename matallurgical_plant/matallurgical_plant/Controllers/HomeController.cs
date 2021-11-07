using matallurgical_plant.Domain;
using matallurgical_plant.Models;
using matallurgical_plant.Services;
using matallurgical_plant.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

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

        [HttpGet]
        public IActionResult Add(int id)
        {
            var model = _productServices.GetById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Product model)
        {
            _productServices.Create(model);

            return RedirectToAction("Index");
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _productServices.GetById(id);

            return View("EditProduct", model);
        }

        [HttpPost]
        public IActionResult EditProduct(Product model)
        {
            _productServices.Edit(model.Id, model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _productServices.GetById(id);

            return View("Details", model);
        }
    }
}
