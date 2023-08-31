using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;

namespace HSRC_RMS.Controllers
{
    public class LicenseController : Controller
    {
    
        private readonly IRepository<LicenseRemainder> _remainderRepository;
        private readonly IRepository<Users> _userRepository;

        public LicenseController(IRepository<LicenseRemainder> remainderRepository, IRepository<Users> userRepository)
        {
            _remainderRepository = remainderRepository;
            _userRepository = userRepository;

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LicenseRemainderGet model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Hardcoded user ID for testing
                    int hardcodedUserId = 1;
                    model.NewLicenseRemainder.UserId = hardcodedUserId;

                    await _remainderRepository.AddAsync(model.NewLicenseRemainder);
                    await _remainderRepository.SaveAsync();

                    TempData["CloseModal"] = true;
                    TempData["SuccessMessage"] = "License registered successfully.";

                    //return RedirectToAction("Index", "LicenseList");
                }
                catch (Exception ex)
                {
                    // Log the exception using your preferred logging mechanism
                    Console.WriteLine(ex.ToString()); // Not the best practice for logging

                    ModelState.AddModelError("", "An error occurred while saving the license.");
                }
            }
            else
            {
                // Collect validation errors
                var validationErrors = ModelState.Values.SelectMany(v => v.Errors)
                                                         .Select(e => e.ErrorMessage)
                                                         .ToList();

                // Store validation errors in TempData
                TempData["ValidationErrors"] = validationErrors;
            }
            // Collect validation errors


            // Pass validation errors to the view

            // Return the view with model and validation errors
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var licenseCaptureGet = new LicenseRemainderGet();

            licenseCaptureGet.UsersOptionAsync = await _userRepository.UsersOptionAsync();
           
            // Populate other properties if needed
            return View(licenseCaptureGet);
        }
    
    }
}
