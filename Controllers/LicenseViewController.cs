﻿using Microsoft.AspNetCore.Mvc;

namespace HSRC_RMS.Controllers
{
    public class LicenseViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
