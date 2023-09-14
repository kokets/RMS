using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;


namespace HSRC_RMS.Controllers
{
    public class JointSupervisionsRegisterController : Controller
    {
        private readonly IRepository<JointSupervisionsRegister> _opportunityRegister;
        //private readonly IRepository<OpportunitiesComment> _commentRepository;

        public JointSupervisionsRegisterController(IRepository<JointSupervisionsRegister> opportunityRegister)
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
        public IActionResult Index(JointSupervisionsRegister model)
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

                    TempData["SuccessMessage"] = "Supervision registered successfully.";

                    return RedirectToAction("Index", "JointSupervisionsDisplay");
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
