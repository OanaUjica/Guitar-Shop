using System.Collections.Generic;
using GuitarShop.Models;
using GuitarShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuitarShop.Controllers
{
    public class WishListController : Controller
    {
        private readonly IGuitarInventory _guitarInventory;


        public WishListController(IGuitarInventory guitarInventory)
        {
            _guitarInventory = guitarInventory;
        }

        public IActionResult Index()
        {
            return View();

        }


        /// <summary>
        /// Action method GET invoked when the user chooses as favorite a guitar.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The View page with the new favorite guitar add to a list of favorite guitars.</returns>
        public IActionResult Create(int id)
        {
            var guitar = _guitarInventory.GetGuitarById(id);
            if (guitar == null) return NotFound();

            var wishListGuitar = _guitarInventory.WishList(guitar);
            var wishListGuitars = new List<Guitar>() { wishListGuitar };
            return View(wishListGuitars);
        }


        //public IActionResult Create(int id)
        //{       

        //    var guitar = _guitarInventory.GetGuitarById(id);
        //    if (guitar == null) return NotFound();

        //    //_wishListRepository.AddGuitar(guitar);
        //    //return RedirectToAction(nameof(Index));
        //}
    }
}