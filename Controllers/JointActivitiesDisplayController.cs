using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HSRC.Controllers
{
    public class JointActivitiesDisplayController : Controller
    {

        private readonly IRepository<JointActivitiesRegister> _giftRepository;
        private readonly IRepository<Users> _usersRepository;


        private readonly RmsDbConnect _context;

        public JointActivitiesDisplayController(IRepository<JointActivitiesRegister> giftRepository, IRepository<Users> usersRepository, RmsDbConnect context)
        {
            _giftRepository = giftRepository;
            _usersRepository = usersRepository;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var giftDisplayList = _giftRepository.GetAll()
                    .Select(opportunities => new JointActivitiesDisplay
                    {
                        ActivityID = opportunities.ActivityID,
                        Budgetyears = opportunities.Budgetyears,
                        Activity = opportunities.Activity,
                        Title = opportunities.Title,
                        Institution = opportunities.Institution,
                        Descriptions = opportunities.Descriptions,
                        Status = opportunities.Status,
                        Collaboration = opportunities.Collaboration,
                        Dates = opportunities.Dates,
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
