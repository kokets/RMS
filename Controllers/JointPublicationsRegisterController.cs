using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class JointPublicationsRegisterController : Controller
    {
        private readonly IRepository<JointPublicationsRegister> _opportunityRegister;
        //private readonly IRepository<OpportunitiesComment> _commentRepository;

        public JointPublicationsRegisterController(IRepository<JointPublicationsRegister> opportunityRegister)
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
        public IActionResult Index(JointPublicationsRegister model)
        {
            //Hardcoded user ID for testing
            
            if (ModelState.IsValid)
            {
                try
                {
                   

                    //add the opportuinity
                    _opportunityRegister.Add(model);
                    _opportunityRegister.Save();




                    //_commentRepository.Add(defaultComment);
                    //_commentRepository.Save();

                    TempData["SuccessMessage"] = "Opportunity registered successfully.";

                    return RedirectToAction("Index", "JointPublicationsDisplay");
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
