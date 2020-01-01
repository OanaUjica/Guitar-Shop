using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuitarShop.Controllers
{
    public class GuitarController : Controller
    {
        private readonly IGuitarInventory _guitarInventory;

        public GuitarController(IGuitarInventory guitarInventory)
        {
            _guitarInventory = guitarInventory;
        }


        /// <summary>
        /// Action method GET.
        /// </summary>
        /// <returns>
        /// View page with the list of all the guitars.
        /// </returns>
        public IActionResult Index()
        {
            var guitars = _guitarInventory.GetAllGuitars();
            return View(guitars);
        }


        /// <summary>
        /// Action method GET.
        /// </summary>
        /// <returns>
        /// View page with the search of guitars form.
        /// </returns>
        public IActionResult Search()
        {
            return View();
        }


        /// <summary>
        /// Action method POST that takes as parameters the fields completed by the user and bind them with the inventory guitars.
        /// </summary>
        /// <param name="guitars"></param>
        /// <returns>
        /// View page with the list of matching guitars or with a validation error message in case of wrong input.
        /// </returns>
        [HttpPost]
        public IActionResult MatchingGuitars([Bind("Builder,Model,Type,BackWood,TopWood")] Guitar guitars)
        {
            var matchingGuitars = new List<Guitar>();
            if (ModelState.IsValid)
            {
                if (guitars != null)
                {
                    matchingGuitars = _guitarInventory.Search(guitars);
                    if (matchingGuitars.Count != 0) return View(matchingGuitars);
                    else return RedirectToAction(nameof(NoMatchingGuitars));
                }
                else return NotFound();

            }
            return RedirectToAction(nameof(Search));
        }


        /// <summary>
        /// Action method GET invoked only if there is no matching guitars with the input form entered by the user.
        /// </summary>
        /// <returns>
        /// View page with a message for user.
        /// </returns>
        public IActionResult NoMatchingGuitars()
        {
            return View();
        }


        public IActionResult Details(int id)
        {
            var guitar = _guitarInventory.GetGuitarById(id);
            if (guitar == null) return NotFound();

            return View(guitar);
        }
    }
}