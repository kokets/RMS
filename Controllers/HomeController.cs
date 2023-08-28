using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HSRC_RMS.Helpers;


namespace HSRC_RMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }
        // Disposing the _dbConnect instance when the controller is disposed
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _dbConnect.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        public IActionResult Index()
        {
         

            return View();
        }

        public IActionResult Privacy()
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