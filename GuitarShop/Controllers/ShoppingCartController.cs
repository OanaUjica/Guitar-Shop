using System.Collections.Generic;
using System.Linq;
using GuitarShop.Models;
using GuitarShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuitarShop.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly IGuitarInventory _guitarInventory;


        public ShoppingCartController(IGuitarInventory guitarInventory)
        {
            _guitarInventory = guitarInventory;
        }


        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<ShoppingCartItem>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Guitar.Price * item.Quantity);
            return View();
        }


        public IActionResult AddToShoppingCart(int id)
        {
            var guitar = _guitarInventory.GetGuitarById(id);
            if (guitar == null) return NotFound();

            if (SessionHelper.GetObjectFromJson<List<ShoppingCartItem>>(HttpContext.Session, "cart") == null)
            {
                List<ShoppingCartItem> cart = new List<ShoppingCartItem>();
                cart.Add(new ShoppingCartItem { Guitar = guitar, Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {                
                List<ShoppingCartItem> cart = SessionHelper.GetObjectFromJson<List<ShoppingCartItem>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;                    
                }
                else
                {
                    cart.Add(new ShoppingCartItem { Guitar = guitar, Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Delete(int id)
        {
            var guitar = _guitarInventory.GetGuitarById(id);
            if (guitar != null) return View(guitar);
            return NotFound();
        }


        [HttpPost]
        public IActionResult ConfirmedDelete(int id)
        {
            List<ShoppingCartItem> cart = SessionHelper.GetObjectFromJson<List<ShoppingCartItem>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction(nameof(Index));
        }

        private int isExist(int id)
        {
            List<ShoppingCartItem> cart = SessionHelper.GetObjectFromJson<List<ShoppingCartItem>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; ++i)
            {
                if (cart[i].Guitar.Id == id) return i;
            }
            return -1;
        }
    }
}