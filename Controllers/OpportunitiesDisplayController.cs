using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HSRC.Controllers
{
    public class OpportunitiesDisplayController : Controller
    {

        private readonly IRepository<OpportunitiesRegister> _giftRepository;
        private readonly IRepository<Users> _usersRepository;


        private readonly RmsDbConnect _context;

        public OpportunitiesDisplayController(IRepository<OpportunitiesRegister> giftRepository, IRepository<Users> usersRepository, RmsDbConnect context)
        {
            _giftRepository = giftRepository;
            _usersRepository = usersRepository;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var giftDisplayList = _giftRepository.GetAll()
                    .Select(opportunities => new OpportunitiesDisplay
                    {
                        opportunityId = opportunities.opportunityId,

                        UserId = opportunities.UserId,
                        Title = opportunities.Title,
                        Funder = opportunities.Funder,
                        Program = opportunities.Program,
                        Status = opportunities.Status,
                        Url = opportunities.Url,
                        SubmissionDate = opportunities.SubmissionDate,
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
