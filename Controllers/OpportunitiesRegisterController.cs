using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class OpportunitesRegisterController : Controller
    {
        private readonly IRepository<OpportunitiesRegister> _opportunityRegister;
        //private readonly IRepository<OpportunitiesComment> _commentRepository;

        public OpportunitesRegisterController(IRepository<OpportunitiesRegister> opportunityRegister)
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
        public IActionResult Index(OpportunitiesRegister model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Hardcoded user ID for testing
                    int hardcodedUserId = 1;
                    model.UserId = hardcodedUserId;

                    //add the opportuinity
                    _opportunityRegister.Add(model);
                    _opportunityRegister.Save();


                   

                    //_commentRepository.Add(defaultComment);
                    //_commentRepository.Save();

                    TempData["SuccessMessage"] = "Opportunity registered successfully.";

                    return RedirectToAction("Index", "OpportunitiesDisplay");
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
