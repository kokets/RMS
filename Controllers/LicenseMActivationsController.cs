using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.CodeAnalysis.FlowAnalysis;

namespace HSRC_RMS.Controllers
{
    public class LicenseMActivationsController : Controller
    {
        private readonly IRepository<LicenseCapture> _captureRepository;
        private readonly IRepository<LicenseSupplies> _supplyRepository;
        private readonly IRepository<LicenseType> _typeRepository;
        private readonly IRepository<Users> _userRepository;
        private readonly IRepository<LicenseActivation> _activationRepository;

        public LicenseMActivationsController(IRepository<LicenseCapture> captureRepository, IRepository<LicenseSupplies> supplyRepository, IRepository<LicenseType> typeRepository, IRepository<Users> userRepository, IRepository<LicenseActivation> activationRepository)
        {
            _captureRepository = captureRepository;
            _supplyRepository = supplyRepository;
            _userRepository = userRepository;
            _typeRepository = typeRepository;
            _activationRepository= activationRepository;

        }
        public IActionResult Index()
        {
            return View();
        }
        //[HttpGet]
        //public async Task<IActionResult> PActivation1(int captureId)
        //{
        //    try
        //    {
        //        List<LicenseCapture> captureList = await _captureRepository.GetLicenseIdAsync(captureId);

        //        //List<LicenseActivation> activationList = await _activationRepository.GetActivationIdAsync()

        //        LicenseActivationGet viewModel = new LicenseActivationGet
        //        {
        //            LicenseActivationList = captureList,
        //            NewActivationView = new LicenseCapture()
        //        };
        //        viewModel.UsersOptionAsync = await _userRepository.UsersOptionAsync();

        //        return PartialView(viewModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
        //        return PartialView();
        //    }
        //}
        [HttpGet]
        public async Task<IActionResult> Index(int captureId)
        {
            try
            {
                List<LicenseCapture> captureList = await _captureRepository.GetLicenseIdAsync(captureId);

                //List<LicenseActivation> activationList = await _activationRepository.GetActivationIdAsync()

                LicenseActivationGet viewModel = new LicenseActivationGet
                {
                    LicenseActivationList = captureList,
                    NewActivationView = new LicenseCapture()
                };
                viewModel.UsersOptionAsync = await _userRepository.UsersOptionAsync();

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
                return View();
            }

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


        //          await  _activationRepository.AddAsync(model.NewActivation);
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
