using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;


namespace HSRC_RMS.Controllers
{
    public class LicenseMSupplierController : Controller
    {
        private readonly IRepository<LicenseSupplies> _supplyRepository;

        public LicenseMSupplierController(IRepository<LicenseSupplies> supplyRepository)
        {
            _supplyRepository = supplyRepository;
        }
   


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(LicenseSupplies viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            // Hardcoded user ID for testing
        //            int hardcodedUserId = 1;
        //            viewModel.UserId = hardcodedUserId;

        //            // Add the license supply
        //            _supplyRepository.Add(viewModel);
        //            _supplyRepository.Save();

        //            TempData["SuccessMessage"] = "License added successfully.";


        //        }
        //        catch (Exception ex)
        //        {
        //            TempData["ErrorMessage"] = "An error occurred while updating the gift: " + ex.Message;
        //        }
        //    }


        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                int? userId = HttpContext.Session.GetInt32("UserId");
                if(userId.HasValue)
                {
                    List<LicenseSupplies> supplierList = await _supplyRepository.GetSuppliesByUserIdAsync(userId.Value);
                    LicenseSuppliesGet viewModel = new LicenseSuppliesGet
                    {
                        LicenseSupplyList = supplierList,
                        NewLicenseSupply = new LicenseSupplies()
                    };

                    return View(viewModel);
                }
                else
                {
                    TempData["ErrorMessage"] = "User information not found in the session. Please log in.";
                    return    RedirectToAction("Index", "Login"); // Redirect to a login page or handle the case as needed.

                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
                return View();
            }

        }


  
    }

}
