using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Ensure this using directive is present
using System.Linq;
using System.Threading.Tasks;

namespace HSRC_RMS.Controllers
{
    public class LicenseMActivationsController : Controller
    {
        private readonly IRepository<LicenseCapture> _captureRepository;
        private readonly IRepository<LicenseSupplies> _supplyRepository;
        private readonly IRepository<LicenseType> _typeRepository;
        private readonly IRepository<Users> _userRepository;
        private readonly IRepository<LicenseActivation> _activationRepository;
        private readonly RmsDbConnect _dbConnect;

        public LicenseMActivationsController(RmsDbConnect dbConnect, IRepository<LicenseCapture> captureRepository, IRepository<LicenseSupplies> supplyRepository, IRepository<LicenseType> typeRepository, IRepository<Users> userRepository, IRepository<LicenseActivation> activationRepository)
        {
            _captureRepository = captureRepository;
            _supplyRepository = supplyRepository;
            _userRepository = userRepository;
            _typeRepository = typeRepository;
            _activationRepository = activationRepository;
            _dbConnect = dbConnect;


        }

        [HttpGet]
        public async Task<IActionResult> Index(int captureId)
        {
            try
            {

                HttpContext.Session.SetInt32("CaptureId", captureId);



                List<LicenseCapture> captureList = await _captureRepository.GetLicenseIdAsync(captureId);


                List<LicenseActivation> activationList = await _activationRepository.GetLicenseActivations(captureId);
                foreach (var activation in activationList)
                {
                    Console.WriteLine($"Activation ID: {activation.ActivationId}");
                    Console.WriteLine($"License User: {activation.LicenseUser}");
                    Console.WriteLine($"Activated Date: {activation.ActivatedDate}");
                    Console.WriteLine($"Expiry Date: {activation.ExpiryDate}");

                    // Output other properties as needed

                    Console.WriteLine(); // Add a blank line for separation
                }
                //List<LicenseActivation> activationList = await _activationRepository.GetActivationIdAsync()

                LicenseActivationGet viewModel = new LicenseActivationGet
                {
                    LicenseActivationList = captureList,
                    NewActivationView = new LicenseCapture(),
                    ActivationList = activationList,

                };

                viewModel.UsersOptionAsync = await _userRepository.UsersOptionAsync();
                ViewBag.CaptureId = captureId;
                return View(viewModel);

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
                return View();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int activationId)
        {
            try
            {
                var captureId = HttpContext.Session.GetInt32("CaptureId");

                Console.WriteLine(activationId);

                await _activationRepository.DeleteActivationIdAsync(activationId);

                return RedirectToAction("Index", "LicenseMActivations", new { captureId = captureId.Value });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index", "MoUManage1Delete");

            }


        }

        [HttpGet]
        public async Task<IActionResult> DownloadPdf(int captureId, int activationId)
        {
            // Retrieve the LicenseActivation by ID
            var licenseActivation = await _dbConnect.LicenseActivation
                .Where(activation => activation.CaptureId == captureId && activation.ActivationId == activationId)
                .FirstOrDefaultAsync();

            if (licenseActivation == null)
            {
                return NotFound(); // Handle not found case
            }

            // Assuming you have a property in LicenseActivation for the PDF content
            // Replace 'PdfContent' with the actual property name in your model
            var pdfContent = licenseActivation.AccessFile;

            if (pdfContent == null)
            {
                return NotFound(); // Handle missing PDF content
            }

            // Return the PDF file as a downloadable file
            return File(pdfContent, "application/pdf", "license.pdf");
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Index(LicenseActivationGet model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            // Hardcoded user ID for testing
        //            int hardcodedUserId = 1;
        //            model.NewActivation.UserId = hardcodedUserId;


        //            await _activationRepository.AddAsync(model.NewActivation);
        //            await _captureRepository.SaveAsync(); // Assuming SaveAsync is the asynchronous method

        //            TempData["CloseModal"] = true;


        //            TempData["SuccessMessage"] = "License  registered successfully.";

        //            //return RedirectToAction("Index", "LicenseList");
        //        }
        //        catch (Exception)
        //        {
        //            ModelState.AddModelError("", "An error occurred while saving the gift.");
        //        }
        //    }
        //    else
        //    {
        //        var validationErrors = ModelState.Values
        //            .SelectMany(v => v.Errors)
        //            .Select(e => e.ErrorMessage)
        //            .ToList();

        //        TempData["ValidationErrors"] = validationErrors;
        //    }

        //    model.UsersOptionAsync = await _userRepository.UsersOptionAsync();

        //    return View(model);
        //}


    }
}
