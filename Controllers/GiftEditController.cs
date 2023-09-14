using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HSRC_RMS.Controllers
{
    public class GiftEditController : Controller
    {
        private readonly ILogger<GiftEditController> _logger;
        private readonly IRepository<OpportunitiesRegister> _giftRepository;

        public GiftEditController(ILogger<GiftEditController> logger, IRepository<OpportunitiesRegister> giftRepository)
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
            var giftEdit = new OpportunitiesRegister
            {
                opportunityId = giftToEdit.opportunityId,

                UserId = giftToEdit.UserId,
                Title = giftToEdit.Title,
                Funder = giftToEdit.Funder,
                Program = giftToEdit.Program,
                Status = giftToEdit.Status,
                Url = giftToEdit.Url,
                SubmissionDate = giftToEdit.SubmissionDate,
            };
            return View(giftEdit); // Use the same view for display and edit
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(OpportunitiesRegister model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var giftToUpdate = _giftRepository.GetById(model.opportunityId);
                    if (giftToUpdate == null)
                    {
                        TempData["ErrorMessage"] = "Gift not found.";
                    }

                    // Update the properties from the model
                    giftToUpdate.Title = model.Title;
                    giftToUpdate.Funder = model.Funder;
                    giftToUpdate.Program = model.Program;
                    giftToUpdate.Status = model.Status;
                    giftToUpdate.Url = model.Url;
                    giftToUpdate.SubmissionDate = model.SubmissionDate;

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
