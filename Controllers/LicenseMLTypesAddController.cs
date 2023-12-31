﻿using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HSRC_RMS.Controllers
{
    public class LicenseMLTypesAddController : Controller
    {
        private readonly IRepository<LicenseType> _typeRepository;

        public LicenseMLTypesAddController(IRepository<LicenseType> typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LicenseType model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Hardcoded user ID for testing

                    int? userId = HttpContext.Session.GetInt32("UserId");
                    if (userId.HasValue)
                    {
                        model.UserId = userId.Value;

                        //add the gift
                        _typeRepository.Add(model);
                        _typeRepository.Save();



                        TempData["SuccessMessage"] = "License Type registered successfully.";

                        return RedirectToAction("Index", "LicenseMLTypes");
                    }
                    else
                    {
                        return RedirectToAction(" Index", "Login");
                    }
                
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "An error occurred while saving the gift.");
                }
            }

            return View(model);
        }
    }
}
