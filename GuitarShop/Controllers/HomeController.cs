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
        /// <summary>
        /// Action method GET 
        /// </summary>
        /// <returns>
        /// Main page of the application
        /// </returns>
        public IActionResult Index()
        {
            return View();
        }

    }
}