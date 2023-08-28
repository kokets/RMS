using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net.NetworkInformation;

namespace HSRC_RMS.Controllers
{
    public class LicenseMSupplierEditController : Controller
    {
        private readonly IRepository<LicenseSupplies> _supplyRepository;


        public LicenseMSupplierEditController(IRepository<LicenseSupplies> supplyRepository)
        {
            _supplyRepository = supplyRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var LicenseToEdit = await _supplyRepository.GetByIdAsync(id);
            if (LicenseToEdit == null)
            {
                return NotFound();
            }

            var LicenseEdit = new LicenseSupplies
            {
                SupplierId = LicenseToEdit.SupplierId,
                Supplier = LicenseToEdit.Supplier,
                Contact = LicenseToEdit.Contact,
                EmailAddress = LicenseToEdit.EmailAddress,
                Status = LicenseToEdit.Status,
            };

            return View(LicenseEdit); // Use the same view for display and edit
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LicenseSupplies model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var LicenseToUpdate = await _supplyRepository.GetByIdAsync(model.SupplierId);
                    if (LicenseToUpdate == null)
                    {
                        TempData["ErrorMessage"] = "License Supply not found.";
                        return NotFound();
                    }

                    // Update the properties from the model
                    LicenseToUpdate.SupplierId = model.SupplierId;
                    LicenseToUpdate.Supplier = model.Supplier;
                    LicenseToUpdate.Contact = model.Contact;
                    LicenseToUpdate.EmailAddress = model.EmailAddress;
                    LicenseToUpdate.Status = model.Status;

                    await _supplyRepository.UpdateAsync(LicenseToUpdate);
                    await _supplyRepository.SaveAsync();

                    TempData["SuccessMessage"] = "License Supply updated successfully.";
                    return RedirectToAction("Index", "LicenseMSupplier"); // Redirect with success message
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "An error occurred while updating the License Supply: " + ex.Message;
                    return View(model); // Return to the edit view with error message
                }
            }

            // If ModelState is not valid, return to the edit view with the model
            return View(model);
        }

        //[HttpGet]
        //public IActionResult Index(int id)
        //{
        //    var LicenseToEdit = _supplyRepository.GetById(id);
        //    if (LicenseToEdit == null)
        //    {
        //        return NotFound();
        //    }
        //    var LicenseEdit = new LicenseSupplies
        //    {
        //        SupplierId = LicenseToEdit.SupplierId,
        //        Supplier = LicenseToEdit.Supplier,
        //        Contact = LicenseToEdit.Contact,
        //        EmailAddress = LicenseToEdit.EmailAddress,
        //        Status = LicenseToEdit.Status,

        //    };
        //    return View(LicenseEdit); // Use the same view for display and edit
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Index(LicenseSupplies model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var LicenseToUpdate = _supplyRepository.GetById(model.SupplierId);
        //            if (LicenseToUpdate == null)
        //            {
        //                TempData["ErrorMessage"] = "License Supply not found.";
        //            }

        //            // Update the properties from the model
        //            LicenseToUpdate.SupplierId = model.SupplierId;
        //            LicenseToUpdate.Supplier = model.Supplier;
        //            LicenseToUpdate.Contact = model.Contact;
        //            LicenseToUpdate.EmailAddress = model.EmailAddress;
        //            LicenseToUpdate.Status = model.Status;


        //            _supplyRepository.Update(LicenseToUpdate);
        //            _supplyRepository.Save();

        //            TempData["SuccessMessage"] = "License Supply updated successfully.";
        //            return RedirectToAction("Index", "LicenseMSupplier"); // Redirect with success message
        //        }
        //        catch (Exception ex)
        //        {
        //            TempData["ErrorMessage"] = "An error occurred while updating the License Supply: " + ex.Message;
        //            return View(model); // Return to the edit view with error message
        //        }
        //    }

        //    // If ModelState is not valid, return to the edit view with the model
        //    return View(model);
        //}
    }
}
