using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class Delete2Controller : Controller
    {
        private readonly ILogger<Delete2Controller> _logger;

        public Delete2Controller(ILogger<Delete2Controller> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            var models = new List<Team>
            {
                new Team { Id = 1, Name = "Peter Drury", Email = "email@email.com" ,GroupID= "AA"},
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