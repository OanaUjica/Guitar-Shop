using System.Collections.Generic;
using GuitarShop.Database;
using GuitarShop.Models;
using GuitarShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            var wishList = SessionHelper.GetObjectFromJson<List<WishListItem>>(HttpContext.Session, "wishList");
            ViewBag.wishList = wishList;
            return View();

        }


        /// <summary>
        /// Action method GET invoked when the user chooses as favorite a guitar.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The View page with the new favorite guitar add to a list of favorite guitars.</returns>
        public IActionResult AddToWishList(int id)
        {
            var guitar = _guitarInventory.GetGuitarById(id);
            if (guitar == null) return NotFound();

            var getWishList = SessionHelper.GetObjectFromJson<List<WishListItem>>(HttpContext.Session, "wishList");            
            if (SessionHelper.GetObjectFromJson<List<WishListItem>>(HttpContext.Session, "wishList") == null)
            {
                List<WishListItem> wishList = new List<WishListItem>();
                wishList.Add(new WishListItem { Guitar = guitar });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "wishList", wishList);
            }
            else
            {
                List<WishListItem> wishList = SessionHelper.GetObjectFromJson<List<WishListItem>>(HttpContext.Session, "wishList");
                wishList.Add(new WishListItem { Guitar = guitar });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "wishList", wishList);
            }
            //var wishListGuitar = _guitarInventory.WishList(guitar);

            return RedirectToAction(nameof(Index));
        }




        public IActionResult Delete(int id)
        { 
            var guitar = _guitarInventory.GetGuitarById(id);
            if (guitar != null) return View(guitar);
            return NotFound();
        }


        [HttpPost]
        public IActionResult PostDelete(int id)
        {

            return View();
        }

    }

}