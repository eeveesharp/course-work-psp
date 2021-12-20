using matallurgical_plant.Domain;
using matallurgical_plant.Models;
using matallurgical_plant.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

namespace matallurgical_plant.Controllers
{
    public class ContractController : Controller
    {
        private readonly IContractService _contractServices;
        private readonly ISpecificationService _specificationServices;
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly AppDbContext _appDbContext;

        public ContractController(ISpecificationService specificationServices,
            IUserService userService,
            IContractService contractServices,
            IProductService productService,
            AppDbContext appDbContext)
        {
            _userService = userService;
            _specificationServices = specificationServices;
            _contractServices = contractServices;
            _productService = productService;
            _appDbContext = appDbContext;

        }

        [HttpGet]
        public IActionResult DownloadExcelReport()
        {
            var file = _contractServices.GenerateExcelReport();
            using (var stream = new MemoryStream())
            {
                file.SaveAs(stream);
                var content = stream.ToArray();

                file.Dispose();
                return File(content,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "Отчет.xlsx");
            }
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
            var specifications = _specificationServices.GetAll();
            var users = _userService.GetAll();
            ViewBag.Specifications = new SelectList(specifications, "Id", "Id");
            ViewBag.Users = new SelectList(users, "Id", "SecondName");

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Contract model)
        {
            var quantity = _specificationServices.GetById(model.SpecificationId).Product.Quantity;
            var price = _specificationServices.GetById(model.SpecificationId).Product.Price;

            if (model.Quantity <= 0)
            {
                ModelState.AddModelError("Quantity", "Вы не можете указать количество 0 или меньше");
                var specifications = _specificationServices.GetAll();
                var users = _userService.GetAll();
                ViewBag.Specifications = new SelectList(specifications, "Id", "Id");
                ViewBag.Users = new SelectList(users, "Id", "SecondName");
                return View(model);
            }
            else if (model.Quantity > quantity)
            {
                ModelState.AddModelError("Quantity", "Вы не можете указать количество больше чем на складе");
                var specifications = _specificationServices.GetAll();
                var users = _userService.GetAll();
                ViewBag.Specifications = new SelectList(specifications, "Id", "Id");
                ViewBag.Users = new SelectList(users, "Id", "SecondName");
                return View(model);
            }
            else
            {
                model.FinalPrice = (price * model.Quantity).ToString();

                _contractServices.Create(model);

                var product = _productService.GetById(model.Specification.Product.Id);

                product.Quantity -= model.Quantity;

                _productService.Edit(product.Id, product);
            }

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
            var specifications = _specificationServices.GetAll();
            var users = _userService.GetAll();
            ViewBag.Specifications = new SelectList(specifications, "Id", "Id");
            ViewBag.Users = new SelectList(users, "Id", "SecondName");

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(Contract model)
        {
            var quantity = _specificationServices.GetById(model.SpecificationId).Product.Quantity;
            var price = _specificationServices.GetById(model.SpecificationId).Product.Price;

            if (model.Quantity <= 0)
            {
                ModelState.AddModelError("Quantity", "Вы не можете указать количество 0 или меньше");

                return View(model);
            }
            else if (model.Quantity > quantity)
            {
                ModelState.AddModelError("Quantity", "Вы не можете указать количество больше чем на складе");

                return View(model);
            }
            else
            {
                model.FinalPrice = (price * model.Quantity).ToString();
                _contractServices.Edit(model.Id, model);

                var product = _productService.GetById(model.Specification.Product.Id);

                product.Quantity -= model.Quantity;

                _productService.Edit(product.Id, product);
            }

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
