using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
namespace HSRC_RMS.Controllers
{
    public class LicenseMLTypesEditController : Controller
    {
        private readonly IRepository<LicenseType> _typeRepository;


        public LicenseMLTypesEditController(IRepository<LicenseType> typeRepository)
        {
            _typeRepository = typeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var LicenseToEdit = await _typeRepository.GetByIdAsync(id);
            if (LicenseToEdit == null)
            {
                return NotFound();
            }

            var LicenseEdit = new LicenseType
            {
                Type = LicenseToEdit.Type,
                TypeId = LicenseToEdit.TypeId,
                Status = LicenseToEdit.Status,
            };

            return View(LicenseEdit); // Use the same view for display and edit
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LicenseType model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var LicenseToUpdate = await _typeRepository.GetByIdAsync(model.TypeId);
                    if (LicenseToUpdate == null)
                    {
                        TempData["ErrorMessage"] = "License Type not found.";
                        return NotFound();
                    }

                    // Update the properties from the model
                    LicenseToUpdate.TypeId = model.TypeId;
                    LicenseToUpdate.Type = model.Type;
                    LicenseToUpdate.Status = model.Status;

                    await _typeRepository.UpdateAsync(LicenseToUpdate);
                    await _typeRepository.SaveAsync();

                    TempData["SuccessMessage"] = "License Type updated successfully.";
                    return RedirectToAction("Index", "LicenseMLTypes"); // Redirect with success message
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "An error occurred while updating the License Type: " + ex.Message;
                    return View(model); // Return to the edit view with error message
                }
            }

            // If ModelState is not valid, return to the edit view with the model
            return View(model);
        }

        //[HttpGet]
        //public IActionResult Index(int id)
        //{
        //    var LicenseToEdit = _typeRepository.GetById(id);
        //    if (LicenseToEdit == null)
        //    {
        //        return NotFound();
        //    }
        //    var LicenseEdit = new LicenseType
        //    {
        //        Type = LicenseToEdit.Type,
        //        TypeId = LicenseToEdit.TypeId,
        //        Status = LicenseToEdit.Status,
        //    };
        //    return View(LicenseEdit); // Use the same view for display and edit
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Index(LicenseType model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var LicenseToUpdate = await _typeRepository.GetById(model.TypeId);
        //            if (LicenseToUpdate == null)
        //            {
        //                TempData["ErrorMessage"] = "License Type not found.";
        //            }

        //            // Update the properties from the model
        //            LicenseToUpdate.TypeId = model.TypeId;
        //            LicenseToUpdate.Type = model.Type;
        //            LicenseToUpdate.Status = model.Status;


        //            _typeRepository.Update(LicenseToUpdate);
        //            _typeRepository.SaveAsync();

        //            TempData["SuccessMessage"] = "License Type updated successfully.";
        //            return RedirectToAction("Index", "LicenseMLTypes"); // Redirect with success message
        //        }
        //        catch (Exception ex)
        //        {
        //            TempData["ErrorMessage"] = "An error occurred while updating the License Type: " + ex.Message;
        //            return View(model); // Return to the edit view with error message
        //        }
        //    }

        //    // If ModelState is not valid, return to the edit view with the model
        //    return View(model);
        //}
    }
}
