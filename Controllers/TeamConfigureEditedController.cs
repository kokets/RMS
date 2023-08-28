using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class TeamConfigureEditedController : Controller
    {
        private readonly ILogger<TeamConfigureEditedController> _logger;

        public TeamConfigureEditedController(ILogger<TeamConfigureEditedController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            var models = new List<Team>
            {
                new Team { Id = 1, Name = "Peter", Surname= "Drury", Email = "email1@email.com" ,GroupID= "AA", Username= "PDrury"},
                new Team { Id = 2, Name = "John", Surname="Deer", Email = "email2@email.com",GroupID= "DD",Username= "JohnDeer" },
                new Team { Id = 3, Name = "Jane", Surname="Doe", Email = "email3@email.com",GroupID= "DD",Username= "JaneDoe" },
                new Team { Id = 4, Name = "Emily", Surname="Jones", Email = "email4@email.com" ,GroupID= "SS", Username = "EmilyJones"},
                new Team { Id = 5, Name = "Tanya", Surname="Meyer", Email = "Tanyameyer74@gmail.com" ,GroupID= "777", Username = "TMeyer"}
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