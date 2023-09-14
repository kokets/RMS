using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HSRC_RMS.Controllers
{
    public class LicenseMActivationUserController : Controller
    {
        private readonly IRepository<LicenseCapture> _captureRepository;
        private readonly IRepository<LicenseSupplies> _supplyRepository;
        private readonly IRepository<LicenseType> _typeRepository;
        private readonly IRepository<Users> _userRepository;
        private readonly IRepository<LicenseActivation> _activationRepository;

        public LicenseMActivationUserController(IRepository<LicenseCapture> captureRepository, IRepository<LicenseSupplies> supplyRepository, IRepository<LicenseType> typeRepository, IRepository<Users> userRepository, IRepository<LicenseActivation> activationRepository)
        {
            _captureRepository = captureRepository;
            _supplyRepository = supplyRepository;
            _userRepository = userRepository;
            _typeRepository = typeRepository;
            _activationRepository = activationRepository;

        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LicenseActivationUserGet model, IFormFile templateFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var captureId = HttpContext.Session.GetInt32("CaptureId");
                    int? userId = HttpContext.Session.GetInt32("UserId");
                    Console.WriteLine("Invalid ID: " + userId); // Log the ID
                    Console.WriteLine("Invalid ID: " + captureId); // Log the ID

                    if (userId.HasValue)
                    {
                        if (templateFile != null)
                        {
                            if (templateFile.Length > 0)
                            {
                                var tempName = Path.GetFileName(templateFile.FileName);
                                var tempFileExtension = Path.GetExtension(tempName);
                                var newTempName = String.Concat(Guid.NewGuid(), tempFileExtension);



                                var newActivation = new LicenseActivation
                                {
                                    LicenseUser = model.NewActivation.LicenseUser, // Get LicenseUser from user input
                                    ActivatedDate = model.NewActivation.ActivatedDate, // Get ActivatedDate from user input
                                    ExpiryDate = model.NewActivation.ExpiryDate, // Get ExpiryDate from user input
                                    AccessFileName = newTempName,
                                    AccessFileType = tempFileExtension,
                                    UserId = userId.Value, // Set UserId from the session
                                    CaptureId = captureId.Value,
                                };
                               

                                using (var memoryStream =  new MemoryStream())
                                {
                                    await templateFile.CopyToAsync(memoryStream);
                                    memoryStream.Seek(0, SeekOrigin.Begin);
                                    newActivation.AccessFile = memoryStream.ToArray();
                                }

                                await _activationRepository.AddAsync(newActivation);
                                await _activationRepository.SaveAsync();
                                return RedirectToAction("Index", "LicenseMActivations", new { captureId = captureId.Value });
                            }
                        }
                    }
                    else
                    {
                        return RedirectToAction("Index", "Login");

                    }

                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "An error occurred while saving the gift.");
                }
            }
            else
            {
                Console.WriteLine("Model is not valid. Validation errors:");

                foreach (var key in ModelState.Keys)
                {
                    foreach (var error in ModelState[key].Errors)
                    {
                        Console.WriteLine("Property: " + key + ", Error: " + error.ErrorMessage);
                    }
                }
            }

            model.UsersOptionAsync = await _userRepository.UsersOptionAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var licenseCaptureGet = new LicenseActivationUserGet();

            licenseCaptureGet.UsersOptionAsync = await _userRepository.UsersOptionAsync();
           
            // Populate other properties if needed
            return View(licenseCaptureGet);
        }

   

    }
}
