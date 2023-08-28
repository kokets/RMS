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
                int userId = 1;
                List<LicenseSupplies> suppliesList = await _supplyRepository.GetSuppliesByUserIdAsync(userId);


                LicenseSuppliesGet viewModel = new LicenseSuppliesGet
                {
                    LicenseSupplyList = suppliesList,
                    NewLicenseSupply = new LicenseSupplies()
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
                return View();
            }

        }


        //[HttpGet]
        //public IActionResult Edit(int supplierId)
        //{
        //    try
        //    {
        //        LicenseSupplies supply = _supplyRepository.GetById(supplierId);

        //        if (supply == null)
        //        {
        //            // Supply with the specified ID was not found
        //            return NotFound();
        //        }

        //        return View(supply);
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
        //        return View();
        //    }
        //}

        //[HttpPost]
        //public IActionResult SaveChanges(LicenseSupplies supply)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            Update the supply
        //            _supplyRepository.Update(supply);
        //            _supplyRepository.Save();

        //            TempData["SuccessMessage"] = "Supply updated successfully.";
        //            return RedirectToAction("Index"); // Redirect to the supply list after editing
        //        }
        //        catch (Exception ex)
        //        {
        //            TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
        //        }
        //    }

        //    If ModelState is invalid or an error occurred, redisplay the edit form
        //    return View("Index", supply);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult UpdateLicenseSupply(LicenseSupplies model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        try
        //        {
        //            // Hardcoded user ID for testing
        //            int hardcodedUserId = 1;
        //            model.UserId = hardcodedUserId;

        //            //add the gift
        //            _supplyRepository.Add(model);
        //            _supplyRepository.Save();



        //            TempData["SuccessMessage"] = "License added successfully.";

        //            return RedirectToAction("Index", "LicenseSupply");
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
