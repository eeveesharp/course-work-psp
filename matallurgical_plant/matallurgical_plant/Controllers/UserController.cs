using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using matallurgical_plant.Domain;
using matallurgical_plant.Models;
using matallurgical_plant.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace matallurgical_plant.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userServices;
        private readonly AppDbContext _appDbContext;

        public UserController(
            IUserService userServices,
            AppDbContext appDbContext)
        {
            _userServices = userServices;
            _appDbContext = appDbContext;
        }
        // GET: ProductController/Index
        public async Task<IActionResult> Index(string searchString)
        {
            var movies = from m in _appDbContext.Users
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.SecondName.Contains(searchString));
            }

            return View(await movies.ToListAsync());
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
