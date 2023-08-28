using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HSRC.Controllers
{
    public class Projects3Controller : Controller
    {
        private readonly ILogger<Projects3Controller> _logger;

        public Projects3Controller(ILogger<Projects3Controller> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var models = new List<TimeRecordings>
            {
                new TimeRecordings { Id = 1, BudgetYear = "2021/22", Project = "DKAAAA" ,Budgeted_hours= "150", Cost_Of_Budget= "R30 000", Cost_Of_Recorded_Hours = "R14 500" ,Recorded_Hours = "98", Remaining_Cost = "R16 500", Remaining_Hours = "52", Hours = "150"},
                new TimeRecordings { Id = 12, BudgetYear = "2021/22", Project = "BDFFFF" ,Budgeted_hours= "340", Cost_Of_Budget= "R150 000", Cost_Of_Recorded_Hours = "R100 000" ,Recorded_Hours = "250", Remaining_Cost = "R50 000", Remaining_Hours = "90", Hours = "340"},


            };
            return View(models);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}