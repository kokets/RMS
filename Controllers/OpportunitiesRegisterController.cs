using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;

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
        public async Task<IActionResult> Index(OpportunitiesRegister model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Random random = new Random();

                    //Generate a random integer between 1 and 100 (inclusive)
                    int randomNumber = random.Next(1, 150001);
                    int? userId = HttpContext.Session.GetInt32("UserId");

                    if (userId.HasValue)
                    {
                        model.UserId = userId.Value;
                        Console.WriteLine($"UserId: {model.UserId}");
                        model.opportunityId = randomNumber;
                        Console.WriteLine($"UserId: {model.UserId}");

                        // Add the gift
                        await _opportunityRegister.AddAsync(model);
                        await _opportunityRegister.SaveAsync();
                        // Add the default comment
                       
                        TempData["SuccessMessage"] = "Opportunity registered successfully";

                        return RedirectToAction("Index", "OpportunitiesDisplay");
                    }
                    else
                    {
                        // Handle the case where UserId is not found in the session
                        ModelState.AddModelError("", "User information not found. Please log in.");
                        return RedirectToAction("Index", "Login");
                    }
     
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
