using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using matallurgical_plant.Domain;
using matallurgical_plant.Models;
using matallurgical_plant.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace matallurgical_plant.Controllers
{
    public class SpecificationController : Controller
    {
        private readonly ISpecificationService _specificationServices;
        private readonly AppDbContext _db;

        public SpecificationController(
            ISpecificationService specificationServices)
        {
            _specificationServices = specificationServices;

        }
        // GET: ProductController/Index
        public IActionResult Index()
        {
            var model = _specificationServices.GetAll();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            var model = _specificationServices.GetById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Specification model)
        {
            _specificationServices.Create(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _specificationServices.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _specificationServices.GetById(id);

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(Specification model)
        {
            _specificationServices.Edit(model.Id, model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _specificationServices.GetById(id);

            return View("Details", model);
        }
    }
}
