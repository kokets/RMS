using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class AccessGroupsController : Controller
    {
        private readonly ILogger<AccessGroupsController> _logger;

        public AccessGroupsController(ILogger<AccessGroupsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var models = new List<Team>
            {
                new Team { Id = 1, Name = "Peter Drury", Email = "email1@email.com" ,GroupID= "AA"},
                new Team { Id = 2, Name = "John Deer", Email = "email2@email.com",GroupID= "DD" },
                new Team { Id = 3, Name = "Jane Doe", Email = "email3@email.com",GroupID= "DD" },
                new Team { Id = 4, Name = "Emily Jones", Email = "email4@email.com" ,GroupID= "SS"},
                new Team { Id = 5, Name = "Tanya Meyer", Email = "Tanyameyer74@gmail.com" ,GroupID= "AA"}
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