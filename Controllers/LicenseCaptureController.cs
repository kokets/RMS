using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
namespace HSRC_RMS.Controllers
{
    public class LicenseCaptureController : Controller
    {
        private readonly IRepository<LicenseCapture> _captureRepository;
        private readonly IRepository<LicenseSupplies> _supplyRepository;
        private readonly IRepository<LicenseType> _typeRepository;
        private readonly IRepository<Users> _userRepository;

        public LicenseCaptureController(IRepository<LicenseCapture> captureRepository, IRepository<LicenseSupplies> supplyRepository, IRepository<LicenseType> typeRepository, IRepository<Users> userRepository)
        {
            _captureRepository = captureRepository;
            _supplyRepository = supplyRepository;
            _userRepository = userRepository;
            _typeRepository = typeRepository;


        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LicenseCaptureForm model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Hardcoded user ID for testing
                    int hardcodedUserId = 1;
                    model.NewCaptureForm.UserId = hardcodedUserId;

                 
                 await   _captureRepository.AddAsync(model.NewCaptureForm);
                    await _captureRepository.SaveAsync(); // Assuming SaveAsync is the asynchronous method



                    TempData["SuccessMessage"] = "License  registered successfully.";

                    return RedirectToAction("Index", "LicenseList");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "An error occurred while saving the gift.");
                }
            }
            else
            {
                // Log ModelState errors
                foreach (var key in ModelState.Keys)
                {
                    foreach (var error in ModelState[key].Errors)
                    {
                        Console.WriteLine($"ModelState Error - Key: {key}, Error: {error.ErrorMessage}");
                    }
                }
            }
            // If ModelState is not valid, populate dropdown options and return to the edit view with the model
            model.UsersOptionAsync = await _userRepository.UsersOptionAsync();
            model.TypeOptionsAsync = await _typeRepository.TypeOptionsAsync();
            model.SupplierOptionsAsync = await _supplyRepository.SupplierOptionsAsync();
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var licenseCaptureGet = new LicenseCaptureForm();
           
            licenseCaptureGet.UsersOptionAsync = await _userRepository.UsersOptionAsync();
            licenseCaptureGet.TypeOptionsAsync = await _typeRepository.TypeOptionsAsync();
            licenseCaptureGet.SupplierOptionsAsync = await _supplyRepository.SupplierOptionsAsync();
            // Populate other properties if needed
            return View(licenseCaptureGet);
        }
        //model.LicenseCSuppliesList = _supplyRepository.GetLicenseCSuppliesList();
        //model.LicenseCUsersList = _userRepository.GetLicenseCUserList();
        //model.LicenseCTypeList = _typeRepository.GetLicenseCTypeList();
    }
}
