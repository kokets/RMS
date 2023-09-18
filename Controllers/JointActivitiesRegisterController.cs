using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class JointActivitiesRegisterController : Controller
    {
        private readonly IRepository<JointActivitiesRegister> _opportunityRegister;
        //private readonly IRepository<OpportunitiesComment> _commentRepository;

        public JointActivitiesRegisterController(IRepository<JointActivitiesRegister> opportunityRegister)
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
        public IActionResult Index(JointActivitiesRegister model)
        {
            //Hardcoded user ID for testing
            
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

                    return RedirectToAction("Index", "JointActivitiesDisplay");
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
