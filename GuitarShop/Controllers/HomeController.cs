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

        // View of the Main Page
        public IActionResult Index()
        {
            var guitars = _guitarInventory.GetAllGuitars();
            return View(guitars);
        }


        // Returns a View Page with the list of all the guitars
        public IActionResult Guitars()
        {
            var guitars = _guitarInventory.GetAllGuitars();
            return View(guitars);
        }

    }
}