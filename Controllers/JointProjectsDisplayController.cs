using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HSRC.Controllers
{
    public class JointProjectsDisplayController : Controller
    {

        private readonly IRepository<JointProjectsRegister> _giftRepository;
        private readonly IRepository<Users> _usersRepository;


        private readonly RmsDbConnect _context;

        public JointProjectsDisplayController(IRepository<JointProjectsRegister> giftRepository, IRepository<Users> usersRepository, RmsDbConnect context)
        {
            _giftRepository = giftRepository;
            _usersRepository = usersRepository;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var giftDisplayList = _giftRepository.GetAll()
                    .Select(opportunities => new JointProjectsDisplay
                    {
                        ProjectID = opportunities.ProjectID,
                        Budgetyears = opportunities.Budgetyears,

                        BudgetYear = opportunities.BudgetYear,
                        ProjectNumber = opportunities.ProjectNumber,
                        Title = opportunities.Title,
                        Institution = opportunities.Institution,
                        Status = opportunities.Status,
                        StartDate = opportunities.StartDate,
                        EndDate = opportunities.EndDate,
                        Document = opportunities.Document,
                    })
                    .ToList();

            return View(giftDisplayList);
        }


        public IActionResult Details(string id)
        {
            ErrorViewModel model = new ErrorViewModel()
            {
                RequestId = id
            };

            return View(model);
        }
    }
}
