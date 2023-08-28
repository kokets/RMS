using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class AddQuartersController : Controller
    {
        private readonly ILogger<AddQuartersController> _logger;

        public AddQuartersController(ILogger<AddQuartersController> logger)
        {
            _logger = logger;
        }

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

        [HttpGet]
        public ActionResult AccessRequest()
        {
            var request = new AccessRequestModel();
            return View(request);
        }

        [HttpPost]
        public ActionResult AccessRequest(AccessRequestModel model)
        {
            // Send an email or notification to the administrator with the access request information
            // ...

            return RedirectToAction("AccessRequestSubmitted");
        }

        public ActionResult AccessRequestSubmitted()
        {
            return View();
        }
    }
}