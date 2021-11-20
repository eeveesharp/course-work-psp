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
    public class UserController : Controller
    {
        private readonly IUserService _userServices;
        private readonly AppDbContext _db;

        public UserController(
            IUserService userServices)
        {
            _userServices = userServices;

        }
        // GET: ProductController/Index
        public IActionResult Index()
        {
            var model = _userServices.GetAll();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            var model = _userServices.GetById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(User model)
        {
            _userServices.Create(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _userServices.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _userServices.GetById(id);

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(User model)
        {
            _userServices.Edit(model.Id, model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _userServices.GetById(id);

            return View("Details", model);
        }
    }
}
