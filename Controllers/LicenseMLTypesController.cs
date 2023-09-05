using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HSRC_RMS.Controllers
{
    public class LicenseMLTypesController : Controller
    {
        private readonly IRepository<LicenseType> _typeRepository;

        public LicenseMLTypesController(IRepository<LicenseType> typeRepository)
        {
            _typeRepository = typeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {

                int? userId = HttpContext.Session.GetInt32("UserId");

                if (userId.HasValue)
                {
                    List<LicenseType> typeList = await _typeRepository.GetTypeByUserIdAsync(userId.Value);

                    LicenseTypeGet viewModel = new LicenseTypeGet
                    {
                        LicenseTypeList = typeList,
                        NewLicenseType = new LicenseType()
                    };

                    return View(viewModel);
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
                return View();
            }
        }


        //[HttpGet]
        //public IActionResult Index()
        //{
        //    try
        //    {
        //        int userId = 1;
        //        List<LicenseType> typeList = _typeRepository.GetTypeByUserId(userId);


        //        LicenseTypeGet viewModel = new LicenseTypeGet
        //        {
        //            LicenseTypeList = typeList,
        //            NewLicenseType = new LicenseType()
        //        };

        //        return View(viewModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
        //        return View();
        //    }

        //}
    }
}
