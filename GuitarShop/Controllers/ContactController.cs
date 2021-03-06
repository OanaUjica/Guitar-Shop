﻿using GuitarShop.Models;
using GuitarShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuitarShop.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository) => _contactRepository = contactRepository;



        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _contactRepository.AddContact(contact);
                return RedirectToAction("ContactComplete");
            }
            return View(contact);

        }


        public IActionResult ContactComplete()
        {
            return View();
        }
    }
}