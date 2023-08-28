using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class TeamConfigureController : Controller
    {
        private readonly ILogger<TeamConfigureController> _logger;

        public TeamConfigureController(ILogger<TeamConfigureController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var models = new List<Team>
            {
                new Team { Id = 1, Name = "Peter", Surname= "Drury", Email = "email1@email.com" ,GroupID= "AA", Username= "PDrury", active = "No"},
                new Team { Id = 2, Name = "John", Surname="Deer", Email = "email2@email.com",GroupID= "DD",Username= "JohnDeer" , active = "No"},
                new Team { Id = 3, Name = "Jane", Surname="Doe", Email = "email3@email.com",GroupID= "DD",Username= "JaneDoe" , active = "Yes"},
                new Team { Id = 4, Name = "Emily", Surname="Jones", Email = "email4@email.com" ,GroupID= "SS", Username = "EmilyJones", active = "No"},
                new Team { Id = 5, Name = "Tanya", Surname="Meyer", Email = "Tanyameyer74@gmail.com" ,GroupID= "DD", Username = "TMeyer", active = "No"}
            };

            return View(models);
        }

        public IActionResult Delete(int id)
        {

            var models = new List<Team>
            {
                new Team { Id = 1, Name = "Peter Drury", Email = "email@email.com" ,GroupID= "AA"},
                new Team { Id = 2, Name = "John Deer", Email = "email1@email.com",GroupID= "DD" },
                new Team { Id = 3, Name = "Jane Doe", Email = "email2@email.com",GroupID= "DD" }
            };

            if (id == 1)
            {
                return RedirectToAction("Index", "Delete1");

            }
            else if (id == 2)
            {
                return RedirectToAction("Index", "Delete2");

            }
            else if (id == 3)
            {
                return RedirectToAction("Index", "Delete3");
            }
            else
            {
                return RedirectToAction("Index", "Delete1");
            }

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}