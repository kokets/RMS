using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
namespace HSRC_RMS.Controllers
{
    public class JointSupervisionsEditController : Controller
    {
        private readonly IRepository<JointSupervisionsRegister> _captureRepository;
       

        public JointSupervisionsEditController(IRepository<JointSupervisionsRegister> captureRepository)
        {
            _captureRepository = captureRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int academicId)
        {
            try
            {

                JointSupervisionsRegister opportunities = await _captureRepository.GetByIdAsync(academicId);
                //TempData["CaptureData"] = captures;


                JointSupervisionsEditGet viewModel = new JointSupervisionsEditGet
                {
                    NewEditCapture = new JointSupervisionsRegister
                    {
                        SupervisionID = opportunities.SupervisionID,
                        Budgetyears = opportunities.Budgetyears,
                        SuperVisor = opportunities.SuperVisor,
                        Title = opportunities.Title,
                        Institution = opportunities.Institution,
                        Status = opportunities.Status,
                        StartDate = opportunities.StartDate,
                        EndDate = opportunities.EndDate,
                        Document = opportunities.Document,
                    },
                    SupervisionID = academicId
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
        public async Task<IActionResult> Index(JointSupervisionsEditGet model)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    var LicenseToUpdate = await _captureRepository.GetByIdAsync(model.SupervisionID);
                    if (LicenseToUpdate == null)
                    {
                        TempData["ErrorMessage"] = "Supervisor not found.";
                        return NotFound();
                    }

                    // Update properties from the model
                    LicenseToUpdate.Budgetyears = model.NewEditCapture.Budgetyears;
                    LicenseToUpdate.SuperVisor = model.NewEditCapture.SuperVisor;
                    LicenseToUpdate.Title = model.NewEditCapture.Title;
                    LicenseToUpdate.Institution = model.NewEditCapture.Institution;
                    LicenseToUpdate.Status = model.NewEditCapture.Status;
                    LicenseToUpdate.StartDate = model.NewEditCapture.StartDate;
                    LicenseToUpdate.EndDate = model.NewEditCapture.EndDate;
                    LicenseToUpdate.Document = model.NewEditCapture.Document;

                    await _captureRepository.UpdateAsync(LicenseToUpdate);
                    await _captureRepository.SaveAsync(); // Assuming SaveAsync is the asynchronous method

                    TempData["SuccessMessage"] = "Supervisions  updated successfully.";
                    return RedirectToAction("Index", "JointSupervisionsDisplay"); // Redirect with success message
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
        public async Task<IActionResult> Delete(JointSupervisionsEditGet model)
        {
            try
            {
                Console.WriteLine(model.SupervisionID);

                await _captureRepository.DeleteAsync(model.SupervisionID);

                return RedirectToAction("Index", "JointSupervisionsDisplay");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index", "JointSupervisionsDisplay");

            }
        }
    }
}
