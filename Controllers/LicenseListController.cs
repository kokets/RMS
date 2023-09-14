using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace HSRC_RMS.Controllers
{
    public class LicenseListController : Controller
    {
        private readonly IRepository<LicenseCapture> _captureRepository;

        public LicenseListController(IRepository<LicenseCapture> captureRepository)
        {
            _captureRepository = captureRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {

                int? userId = HttpContext.Session.GetInt32("UserId");
                if (userId.HasValue)
                {
                    List<LicenseCapture> captureList = await _captureRepository.GetLicensefieldsByUserIdAsync(userId.Value);


                    LicenseCaptureGet viewModel = new LicenseCaptureGet
                    {
                        LicenseCaptureList = captureList,
                        NewLicenseCapture = new LicenseCapture()
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
    }
}
