using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class TimeRecordingsController : Controller
    {
        private readonly ILogger<TimeRecordingsController> _logger;

        public TimeRecordingsController(ILogger<TimeRecordingsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var models = new List<TimeRecordings>
            {
                new TimeRecordings { Id = 5, BudgetYear = "Tanya Meyer", Project = "Tanyameyer74@gmail.com" ,Budgeted_hours= "AA", Cost_Of_Budget= "Tanya Meyer", Cost_Of_Recorded_Hours = "Tanyameyer74@gmail.com" ,Recorded_Hours = "AA", Remaining_Cost = "Tanya Meyer", Hours = "Tanyameyer74@gmail.com"},

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