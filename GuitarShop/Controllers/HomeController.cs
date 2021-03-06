﻿using Microsoft.AspNetCore.Mvc;

namespace GuitarShop.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Action method GET invoked at the start of the application
        /// </summary>
        /// <returns>Main page of the application</returns>
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View("Error");
        }

    }
}