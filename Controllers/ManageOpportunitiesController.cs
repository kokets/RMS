﻿using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HSRC.Controllers
{
    public class ManageOpportunitiesController : Controller
    {
        private readonly ILogger<ManageOpportunitiesController> _logger;

        public ManageOpportunitiesController(ILogger<ManageOpportunitiesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}