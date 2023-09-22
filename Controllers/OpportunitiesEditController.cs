using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
namespace HSRC_RMS.Controllers
{
    public class OpportunitiesEditController : Controller
    {
        private readonly IRepository<OpportunitiesRegister> _captureRepository;


        public OpportunitiesEditController(IRepository<OpportunitiesRegister> captureRepository)
        {
            _captureRepository = captureRepository;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var opportunities = _captureRepository.GetById(id);
            if (opportunities == null)
            {
                return NotFound();
            }
            var giftEdit = new OpportunitiesRegister
            {
                opportunityId = opportunities.opportunityId,

                UserId = opportunities.UserId,
                Title = opportunities.Title,
                Funder = opportunities.Funder,
                Program = opportunities.Program,
                Status = opportunities.Status,
                Url = opportunities.Url,
                SubmissionDate = opportunities.SubmissionDate,
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
                    var LicenseToUpdate = _captureRepository.GetById(model.opportunityId);
                    if (LicenseToUpdate == null)
                    {
                        TempData["ErrorMessage"] = "Opportunity not found.";
                        return NotFound();
                    }

                    // Update properties from the model
                    LicenseToUpdate.Funder = model.Funder;
                    LicenseToUpdate.Title = model.Title;
                    LicenseToUpdate.Program = model.Program;
                    LicenseToUpdate.Status = model.Status;
                    LicenseToUpdate.Url = model.Url;
                    LicenseToUpdate.SubmissionDate = model.SubmissionDate;

                    _captureRepository.UpdateAsync(LicenseToUpdate);
                    _captureRepository.SaveAsync(); // Assuming SaveAsync is the asynchronous method

                    TempData["SuccessMessage"] = "Opportunity  updated successfully.";
                    return RedirectToAction("Index", "OpportunitiesDisplay"); // Redirect with success message
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "An error occurred while updating the Supervivisor Type: " + ex.Message;
                    return View(model); // Return to the edit view with error message
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
            // If ModelState is not valid, populate dropdown options and return to the edit view with the model
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(OpportunitiesRegister model)
        {
            try
            {
                Console.WriteLine(model.opportunityId);

                await _captureRepository.DeleteAsync(model.opportunityId);

                return RedirectToAction("Index", "OpportunitiesDisplay");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index", "OpportunitiesDisplay");

            }
        }
    }
}
