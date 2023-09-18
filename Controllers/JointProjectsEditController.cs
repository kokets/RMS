using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
namespace HSRC_RMS.Controllers
{
    public class JointProjectsEditController : Controller
    {
        private readonly IRepository<JointProjectsRegister> _captureRepository;
       

        public JointProjectsEditController(IRepository<JointProjectsRegister> captureRepository)
        {
            _captureRepository = captureRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int academicId)
        {
            try
            {

                JointProjectsRegister opportunities = await _captureRepository.GetByIdAsync(academicId);
                //TempData["CaptureData"] = captures;


                JointProjectsEditGet viewModel = new JointProjectsEditGet
                {
                    NewEditCapture = new JointProjectsRegister
                    {
                        ProjectID = opportunities.ProjectID,
                        Budgetyears = opportunities.Budgetyears,
                        ProjectNumber = opportunities.ProjectNumber,
                        Title = opportunities.Title,
                        Institution = opportunities.Institution,
                        Status = opportunities.Status,
                        StartDate = opportunities.StartDate,
                        EndDate = opportunities.EndDate,
                        Document = opportunities.Document,
                    },
                    ProjectID = academicId
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
        public async Task<IActionResult> Index(JointProjectsEditGet model)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    var LicenseToUpdate = await _captureRepository.GetByIdAsync(model.ProjectID);
                    if (LicenseToUpdate == null)
                    {
                        TempData["ErrorMessage"] = "Academic Opportunity not found.";
                        return NotFound();
                    }

                    // Update properties from the model
                    LicenseToUpdate.Budgetyears = model.NewEditCapture.Budgetyears;
                    LicenseToUpdate.ProjectNumber = model.NewEditCapture.ProjectNumber;
                    LicenseToUpdate.Title = model.NewEditCapture.Title;
                    LicenseToUpdate.Institution = model.NewEditCapture.Institution;
                    LicenseToUpdate.Status = model.NewEditCapture.Status;
                    LicenseToUpdate.StartDate = model.NewEditCapture.StartDate;
                    LicenseToUpdate.EndDate = model.NewEditCapture.EndDate;
                    LicenseToUpdate.Document = model.NewEditCapture.Document;

                    await _captureRepository.UpdateAsync(LicenseToUpdate);
                    await _captureRepository.SaveAsync(); // Assuming SaveAsync is the asynchronous method

                    TempData["SuccessMessage"] = "License  updated successfully.";
                    return RedirectToAction("Index", "JointProjectsDisplay"); // Redirect with success message
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
        public async Task<IActionResult> Delete(JointProjectsEditGet model)
        {
            try
            {
                Console.WriteLine(model.ProjectID);

                await _captureRepository.DeleteAsync(model.ProjectID);

                return RedirectToAction("Index", "JointProjectsDisplay");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index", "JointProjectsDisplay");

            }
        }


    }
}
