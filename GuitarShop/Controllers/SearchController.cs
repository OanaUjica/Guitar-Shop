using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuitarShop.Controllers
{
    public class SearchController : Controller
    {

        private readonly IGuitarInventory _guitarInventory;

        public SearchController(IGuitarInventory guitarInventory)
        {
            _guitarInventory = guitarInventory;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SearchCompleted([Bind("Builder,Model,Type,BackWood,TopWood")] Guitar guitars)
        {
            var matchingGuitars = new List<Guitar>();
            if (ModelState.IsValid && guitars != null)
            {
                matchingGuitars = _guitarInventory.Search(guitars);
                return View(matchingGuitars);
            }
            return RedirectToAction(nameof(Index));

        }

    }
}