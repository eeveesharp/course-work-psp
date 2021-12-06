using matallurgical_plant.Domain;
using matallurgical_plant.Models;
using matallurgical_plant.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace matallurgical_plant.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productServices;
        private readonly AppDbContext _appDbContext;

        public ProductController(
            IProductService productServices,
            AppDbContext appDbContext)
        {
            _productServices = productServices;
            _appDbContext = appDbContext;

        }
        // GET: ProductController/Index
        public async Task<IActionResult> Index(string searchString)
        {
            var movies = from m in _appDbContext.Products
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.NameProduct.Contains(searchString));
            }

            return View(await movies.ToListAsync());
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
            if (model.Quantity <= 0)
            {
                ModelState.AddModelError("Quantity", "Количество не может быть меньше либо равно 0");

                return View(model);
            }
            else
            {
                _productServices.Create(model);
            }            

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

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(Product model)
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
