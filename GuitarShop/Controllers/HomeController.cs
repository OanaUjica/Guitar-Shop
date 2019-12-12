using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuitarShop.Controllers
{
    public class HomeController : Controller
    {

        private readonly IGuitarInventory _guitarInventory;

        public HomeController(IGuitarInventory guitarInventory)
        {
            _guitarInventory = guitarInventory;
        }


        public IActionResult Index()
        {
            var guitars = _guitarInventory.GetAllGuitars();
            return View(guitars);
        }


        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

    }
}