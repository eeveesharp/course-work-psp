using matallurgical_plant.Domain;
using matallurgical_plant.Models;
using matallurgical_plant.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace matallurgical_plant.Controllers
{
    public class ContractController : Controller
    {
        private readonly IContractService _contractServices;

        public ContractController(
            IContractService contractServices)
        {
            _contractServices = contractServices;

        }
        // GET: ProductController/Index
        public IActionResult Index()
        {
            var model = _contractServices.GetAll();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            var model = _contractServices.GetById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Contract model)
        {
            _contractServices.Create(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _contractServices.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _contractServices.GetById(id);

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(Contract model)
        {
            _contractServices.Edit(model.Id, model);       

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _contractServices.GetById(id);

            return View("Details", model);
        }
    }
}
