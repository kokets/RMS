using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
namespace HSRC_RMS.Controllers
{
    public class JointAcademicEditController : Controller
    {
        private readonly IRepository<JointAcademicRegister> _captureRepository;
       

        public JointAcademicEditController(IRepository<JointAcademicRegister> captureRepository)
        {
            _captureRepository = captureRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int academicId)
        {
            try
            {

                JointAcademicRegister opportunities = await _captureRepository.GetByIdAsync(academicId);
                //TempData["CaptureData"] = captures;


                JointAcademicEditGet viewModel = new JointAcademicEditGet
                {
                    NewEditCapture = new JointAcademicRegister
                    {
                        AcademicId = opportunities.AcademicId,
                        Budgetyears = opportunities.Budgetyears,

                        BudgetYear = opportunities.BudgetYear,
                        Staff = opportunities.Staff,
                        Position = opportunities.Position,
                        Institution = opportunities.Institution,
                        Descriptions = opportunities.Descriptions,
                        Status = opportunities.Status,
                        StartDate = opportunities.StartDate,
                        EndDate = opportunities.EndDate,
                        Document = opportunities.Document,
                    },
                    AcademicId = academicId
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
        public async Task<IActionResult> Index(JointAcademicEditGet model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var LicenseToUpdate = await _captureRepository.GetByIdAsync(model.NewEditCapture.AcademicId);
                    if (LicenseToUpdate == null)
                    {
                        TempData["ErrorMessage"] = "Academic Opportunity not found.";
                        return NotFound();
                    }

                    // Update properties from the model
                    LicenseToUpdate.AcademicId = model.NewEditCapture.AcademicId;
                    LicenseToUpdate.Budgetyears = model.NewEditCapture.Budgetyears;

                    LicenseToUpdate.BudgetYear = model.NewEditCapture.BudgetYear;
                    LicenseToUpdate.Staff = model.NewEditCapture.Staff;
                    LicenseToUpdate.Position = model.NewEditCapture.Position;
                    LicenseToUpdate.Institution = model.NewEditCapture.Institution;
                    LicenseToUpdate.Descriptions = model.NewEditCapture.Descriptions;
                    LicenseToUpdate.Status = model.NewEditCapture.Status;
                    LicenseToUpdate.StartDate = model.NewEditCapture.StartDate;
                    LicenseToUpdate.EndDate = model.NewEditCapture.EndDate;
                    LicenseToUpdate.Document = model.NewEditCapture.Document;

                    await _captureRepository.UpdateAsync(LicenseToUpdate);
                    await _captureRepository.SaveAsync(); // Assuming SaveAsync is the asynchronous method

                    TempData["SuccessMessage"] = "License  updated successfully.";
                    return RedirectToAction("Index", "LicenseList"); // Redirect with success message
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


        

    }
}
