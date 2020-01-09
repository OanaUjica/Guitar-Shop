﻿using System.Collections.Generic;
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
        /// Action method GET invoked when the user chooses as favorite a guitar, in the current session.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The View page with the new favorite guitar added to a list of favorite guitars.</returns>
        public IActionResult AddToWishList(int id)
        {
            var guitar = _guitarInventory.GetGuitarById(id);
            if (guitar == null) return NotFound();

                       
            if (SessionHelper.GetObjectFromJson<List<WishListItem>>(HttpContext.Session, "wishList") == null)
            {
                List<WishListItem> wishList = new List<WishListItem>();
                wishList.Add(new WishListItem { Guitar = guitar });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "wishList", wishList);
            }
            else
            {
                var getWishList = SessionHelper.GetObjectFromJson<List<WishListItem>>(HttpContext.Session, "wishList");
                int index = isExist(id);
                if (index != -1)
                {
                    return RedirectToAction(nameof(Index));
                }
                List<WishListItem> wishList = SessionHelper.GetObjectFromJson<List<WishListItem>>(HttpContext.Session, "wishList");
                wishList.Add(new WishListItem { Guitar = guitar });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "wishList", wishList);
            }            

            return RedirectToAction(nameof(Index));
        }



        // Action method GET invoked when the user wants to delete a guitar from the WishList
        public IActionResult Delete(int id)
        { 
            var guitar = _guitarInventory.GetGuitarById(id);
            if (guitar != null) return View(guitar);
            return NotFound();
        }


        // Action method POST invoked after confirmation that the guitar selected can be deleted from the WishList.
        [HttpPost]
        public IActionResult ConfirmedDelete(int id)
        {
            List<WishListItem> wishList = SessionHelper.GetObjectFromJson<List<WishListItem>>(HttpContext.Session, "wishList");
            int index = isExist(id);
            wishList.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "wishList", wishList);
            return RedirectToAction(nameof(Index));
        }


        // Method invoked to verify if there is any guitar in the WishList and the indexes of the guitars if they exist, in the current session.
        private int isExist(int id)
        {
            List<WishListItem> wishList = SessionHelper.GetObjectFromJson<List<WishListItem>>(HttpContext.Session, "wishList");
            for (int i = 0; i < wishList.Count; ++i)
            {
                if (wishList[i].Guitar.Id == id) return i;
            }
            return -1;
        }

    }

}