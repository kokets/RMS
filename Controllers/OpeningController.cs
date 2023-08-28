﻿using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HSRC.Controllers
{
    public class OpeningController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Details(string id)
        {
            ErrorViewModel model = new ErrorViewModel()
            {
                RequestId = id
            };

            return View(model);
        }
    }
}
