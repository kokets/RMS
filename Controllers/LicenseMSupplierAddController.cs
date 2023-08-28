using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HSRC_RMS.Controllers
{
    public class LicenseMSupplierAddController : Controller
    {
        private readonly IRepository<LicenseSupplies> _supplyRepository;

        public LicenseMSupplierAddController(IRepository<LicenseSupplies> supplyRepository)
        {
            _supplyRepository = supplyRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LicenseSupplies model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Hardcoded user ID for testing
                    int hardcodedUserId = 1;
                    model.UserId = hardcodedUserId;

                    // Add the gift asynchronously
                    await _supplyRepository.AddAsync(model);
                    await _supplyRepository.SaveAsync();

                    TempData["SuccessMessage"] = "Gift registered successfully.";

                    return RedirectToAction("Index", "LicenseMSupplier");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "An error occurred while saving the gift.");
                }
            }

            return View(model);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Index(LicenseSupplies model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            // Hardcoded user ID for testing
        //            int hardcodedUserId = 1;
        //            model.UserId = hardcodedUserId;

        //            //add the gift
        //            _supplyRepository.Add(model);
        //            _supplyRepository.Save();



        //            TempData["SuccessMessage"] = "Gift registered successfully.";

        //            return RedirectToAction("Index", "LicenseMSupplier");
        //        }
        //        catch (Exception)
        //        {
        //            ModelState.AddModelError("", "An error occurred while saving the gift.");
        //        }
        //    }

        //    return View(model);
        //}
    }
}
