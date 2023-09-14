using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;


namespace HSRC_RMS.Controllers
{
	public class JointAcademicRegisterController : Controller
	{
		private readonly IRepository<JointAcademicRegister> _opportunityRegister;
		//private readonly IRepository<OpportunitiesComment> _commentRepository;

		public JointAcademicRegisterController(IRepository<JointAcademicRegister> opportunityRegister)
		{
			_opportunityRegister = opportunityRegister;
			//_commentRepository = commentRepository;
		}

		public IActionResult Index()
		{


			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Index(JointAcademicRegister model)
		{
            //Hardcoded user ID for testing
            int hardcodedUserId = 23;
            model.BudgetYear = hardcodedUserId;
            if (!ModelState.IsValid)
			{
				try
				{
					

					//add the opportuinity
					_opportunityRegister.Add(model);
					_opportunityRegister.Save();




					//_commentRepository.Add(defaultComment);
					//_commentRepository.Save();

					TempData["SuccessMessage"] = "Opportunity registered successfully.";

					return RedirectToAction("Index", "JointAcademicDisplay");
				}
				catch (Exception)
				{
					ModelState.AddModelError("", "An error occurred while saving the opportunity.");
				}
			}

			return View(model);
		}
	}
}
