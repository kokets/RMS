using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
namespace HSRC_RMS.Controllers
{
    public class JointActivitiesEditController : Controller
    {
        private readonly IRepository<JointActivitiesRegister> _captureRepository;
       

        public JointActivitiesEditController(IRepository<JointActivitiesRegister> captureRepository)
        {
            _captureRepository = captureRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int academicId)
        {
            try
            {

                JointActivitiesRegister opportunities = await _captureRepository.GetByIdAsync(academicId);
                //TempData["CaptureData"] = captures;


                JointActivitiesEditGet viewModel = new JointActivitiesEditGet
                {
                    NewEditCapture = new JointActivitiesRegister
                    {
                        ActivityID = opportunities.ActivityID,
                        Budgetyears = opportunities.Budgetyears,
                        Activity = opportunities.Activity,
                        Title = opportunities.Title,
                        Institution = opportunities.Institution,
                        Descriptions = opportunities.Descriptions,
                        Status = opportunities.Status,
                        Collaboration = opportunities.Collaboration,
                        Dates = opportunities.Dates,
                        Document = opportunities.Document,
                    },
                    ActivityID = academicId
                };



                //LicenseCaptureGet viewModel = new LicenseCaptureGet
                //{
                //    LicenseCaptureList = await _captureRepository.GetLicenseViewByCaptureIdAsync(captureId),
                //    NewLicenseCapture = new LicenseCapture()
                //};


                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(JointActivitiesEditGet model)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    var LicenseToUpdate = await _captureRepository.GetByIdAsync(model.ActivityID);
                    if (LicenseToUpdate == null)
                    {
                        TempData["ErrorMessage"] = "Activity not found.";
                        return NotFound();
                    }

                    // Update properties from the model
                    LicenseToUpdate.Budgetyears = model.NewEditCapture.Budgetyears;
                    LicenseToUpdate.Activity = model.NewEditCapture.Activity;
                    LicenseToUpdate.Title = model.NewEditCapture.Title;
                    LicenseToUpdate.Institution = model.NewEditCapture.Institution;
                    LicenseToUpdate.Descriptions = model.NewEditCapture.Descriptions;
                    LicenseToUpdate.Status = model.NewEditCapture.Status;
                    LicenseToUpdate.Dates = model.NewEditCapture.Dates;
                    LicenseToUpdate.Collaboration = model.NewEditCapture.Collaboration;
                    LicenseToUpdate.Document = model.NewEditCapture.Document;

                    await _captureRepository.UpdateAsync(LicenseToUpdate);
                    await _captureRepository.SaveAsync(); // Assuming SaveAsync is the asynchronous method

                    TempData["SuccessMessage"] = "License  updated successfully.";
                    return RedirectToAction("Index", "JointActivitiesDisplay"); // Redirect with success message
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "An error occurred while updating the License Type: " + ex.Message;
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
        public async Task<IActionResult> Delete(JointActivitiesEditGet model)
        {
            try
            {
                Console.WriteLine(model.ActivityID);

                await _captureRepository.DeleteAsync(model.ActivityID);

                return RedirectToAction("Index", "JointActivitiesDisplay");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index", "JointActivitiesDisplay");

            }
        }


    }
}
