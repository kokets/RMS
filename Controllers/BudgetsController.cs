using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class BudgetsController : Controller
    {
        private readonly ILogger<BudgetsController> _logger;

        public BudgetsController(ILogger<BudgetsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            var models = new List<BudgetYearModel>
            {

                new BudgetYearModel { Id = 1, budgetYear = "2021/22"},
                 new BudgetYearModel { Id = 2, budgetYear = "2022/23"},

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