using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HSRC.Controllers
{
	public class JointAcademicDisplayController : Controller
	{

		private readonly IRepository<JointAcademicRegister> _giftRepository;
		private readonly IRepository<Users> _usersRepository;


		private readonly RmsDbConnect _context;

		public JointAcademicDisplayController(IRepository<JointAcademicRegister> giftRepository, IRepository<Users> usersRepository, RmsDbConnect context)
		{
			_giftRepository = giftRepository;
			_usersRepository = usersRepository;
			_context = context;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var giftDisplayList = _giftRepository.GetAll()
					.Select(opportunities => new JointAcademicDisplay
					{
						AcademicId = opportunities.AcademicId,
                        Budgetyears = opportunities.Budgetyears,

                        BudgetYear = opportunities.BudgetYear,
						Staff = opportunities.Staff,
						Position = opportunities.Position,
						Institution = opportunities.Institution,
						Descriptions = opportunities.Descriptions,
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
