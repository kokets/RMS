using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HSRC_RMS.Controllers
{
    public class GiftEditController : Controller
    {
        private readonly ILogger<GiftEditController> _logger;
        private readonly IRepository<GiftRegister> _giftRepository;

        public GiftEditController(ILogger<GiftEditController> logger, IRepository<GiftRegister> giftRepository)
        {
            _logger = logger;
            _giftRepository = giftRepository;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var giftToEdit = _giftRepository.GetById(id);
            if (giftToEdit == null)
            {
                return NotFound();
            }
            var giftEdit = new GiftRegister
            {
                GiftId = giftToEdit.GiftId,
                GiftSponsor = giftToEdit.GiftSponsor,
                GiftOrganization = giftToEdit.GiftOrganization,
                NatureOfBusiness = giftToEdit.NatureOfBusiness,
                GiftDescription = giftToEdit.GiftDescription,
                Value = giftToEdit.Value,
                PurposeOfGift = giftToEdit.PurposeOfGift,
                ReceivedInAppreciation = giftToEdit.ReceivedInAppreciation
            };
            return View(giftEdit); // Use the same view for display and edit
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(GiftRegister model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var giftToUpdate = _giftRepository.GetById(model.GiftId);
                    if (giftToUpdate == null)
                    {
                        TempData["ErrorMessage"] = "Gift not found.";
                    }

                    // Update the properties from the model
                    giftToUpdate.GiftSponsor = model.GiftSponsor;
                    giftToUpdate.GiftOrganization = model.GiftOrganization;
                    giftToUpdate.NatureOfBusiness = model.NatureOfBusiness;
                    giftToUpdate.GiftDescription = model.GiftDescription;
                    giftToUpdate.Value = model.Value;
                    giftToUpdate.PurposeOfGift = model.PurposeOfGift;
                    giftToUpdate.ReceivedInAppreciation = model.ReceivedInAppreciation;

                    _giftRepository.Update(giftToUpdate);
                    _giftRepository.Save();

                    TempData["SuccessMessage"] = "Gift updated successfully.";
                    return RedirectToAction("Index", "GiftDisplay"); // Redirect with success message
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "An error occurred while updating the gift: " + ex.Message;
                    return View(model); // Return to the edit view with error message
                }
            }

            // If ModelState is not valid, return to the edit view with the model
            return View(model);
        }


    }
}
