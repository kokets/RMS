using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
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
                int userId = 1;
                List<LicenseCapture> captureList = await _captureRepository.GetLicensefieldsByUserIdAsync(userId);


                LicenseCaptureGet viewModel = new LicenseCaptureGet
                {
                    LicenseCaptureList = captureList,
                    NewLicenseCapture = new LicenseCapture()
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
                return View();
            }

        }
    }
}
