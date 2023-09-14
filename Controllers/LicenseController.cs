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
                    int? userId = HttpContext.Session.GetInt32("UserId");
                    Console.WriteLine(" ID: " + userId); // Log the ID

                    if (!userId.HasValue)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    model.NewLicenseRemainder.UserId = userId.Value;

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
                Console.WriteLine("Model is not valid. Validation errors:");

                foreach (var key in ModelState.Keys)
                {
                    foreach (var error in ModelState[key].Errors)
                    {
                        Console.WriteLine("Property: " + key + ", Error: " + error.ErrorMessage);
                    }
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                int? userId = HttpContext.Session.GetInt32("UserId");
                Console.WriteLine(" ID: " + userId); // Log the ID

                if (!userId.HasValue)
                {
                    return RedirectToAction("Index", "Login");
                }
                List<LicenseRemainder> remainderList = await _remainderRepository.GetRemindersForUser(userId.Value);

                LicenseRemainderGet remainderGet = new LicenseRemainderGet
                {
                    RemainderList = remainderList,
                    NewLicenseRemainder = new LicenseRemainder(),
                };
                return View(remainderGet);

            }
            catch (Exception)
            {
                return View();
            }
        }
        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    try
        //    {
        //       var remainder = await _remainderRepository.GetAllAsync();
        //        //TempData["CaptureData"] = captures;


        //        //LicenseViewGet viewModel = new LicenseViewGet
        //        //{
        //        //    NewViewLicense = new LicenseCapture
        //        //    {
        //        //        LicenseOwner = captureView.LicenseOwner,
        //        //        ProductName = captureView.ProductName,
        //        //        ProductKey = captureView.ProductKey,
        //        //        LicenseType = captureView.LicenseType,
        //        //        AcquiredDate = captureView.AcquiredDate,
        //        //        ExpiryDate = captureView.ExpiryDate,
        //        //        Activations = captureView.Activations,
        //        //        LicenseStatus = captureView.LicenseStatus,
        //        //        Supplier = captureView.Supplier,
        //        //        PurchasePrice = captureView.PurchasePrice,
        //        //        CommentPrice = captureView.CommentPrice
        //        //    },
        //        //    CaptureId = captureId
        //        //};


        //        return View(remainder);
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
        //        return View();
        //    }

        //}
    }
}
