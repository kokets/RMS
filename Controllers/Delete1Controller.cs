using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class Delete1Controller : Controller
    {
        private readonly ILogger<Delete1Controller> _logger;

        public Delete1Controller(ILogger<Delete1Controller> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int id)
        {

            var models = new List<Team>
            {
                new Team { Id = 2, Name = "John Deer", Email = "email1@email.com",GroupID= "DD" },
                new Team { Id = 3, Name = "Jane Doe", Email = "email2@email.com",GroupID= "DD" }
            };

            return View(models);
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