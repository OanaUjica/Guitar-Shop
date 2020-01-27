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

        /// <summary>
        /// Action method GET invoked when the user chooses to buy a guitar, in the current session.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The View page with the new guitar added to a list of shopping cart guitars.</returns>
        public IActionResult AddToShoppingCart(int id)
        {
            var guitar = _guitarInventory.GetGuitarById(id);
            if (guitar == null) return NotFound();

            if (SessionHelper.GetObjectFromJson<List<ShoppingCartItem>>(HttpContext.Session, "cart") == null)
            {
                var cart = new List<ShoppingCartItem>();
                cart.Add(new ShoppingCartItem { Guitar = guitar, Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {                
                var cart = SessionHelper.GetObjectFromJson<List<ShoppingCartItem>>(HttpContext.Session, "cart");

                if (IsGuitarExitingInShoppingCart(id))
                {
                    int index = GetIndexForShoppingCartGuitar(id);
                    if (index != -1)
                    {
                        cart[index].Quantity++;
                    }                                     
                }
                else
                {
                    cart.Add(new ShoppingCartItem { Guitar = guitar, Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction(nameof(Index));
        }


        // Action method GET invoked when the user wants to delete a guitar from the ShoppingCart
        public IActionResult Delete(int id)
        {
            var guitar = _guitarInventory.GetGuitarById(id);
            if (guitar != null)
            {
                return View(guitar);
            }
            return NotFound();
        }

        // Action method POST invoked after confirmation that the guitar selected can be deleted from the ShoppingCart.
        [HttpPost]
        public IActionResult ConfirmedDelete(int id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<ShoppingCartItem>>(HttpContext.Session, "cart");

            if (IsGuitarExitingInShoppingCart(id))
            {
                int index = GetIndexForShoppingCartGuitar(id);
                if (index != -1)
                {
                    cart.RemoveAt(index);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                }
            }
            return RedirectToAction(nameof(Index));
        }


        // Method invoked to verify if there is any guitar in the Shopping Cart in the current session.
        private bool IsGuitarExitingInShoppingCart(int id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<ShoppingCartItem>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; ++i)
            {
                if (cart[i].Guitar.Id == id)
                {
                    return true;
                }

            }
            return false;
        }

        // Method invoked to take the index of the guitar from the Shopping Cart in the current session that has the same Id with the guitar ID introduced as parameter.
        private int GetIndexForShoppingCartGuitar(int id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<ShoppingCartItem>>(HttpContext.Session, "cart");

            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Guitar.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}