using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace HSRC_RMS.Controllers
{
    public class LicenseListViewController : Controller
    {
        private readonly IRepository<LicenseCapture> _captureRepository;

        public LicenseListViewController(IRepository<LicenseCapture> captureRepository)
        {
            _captureRepository = captureRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int captureId)
        {
            try
            {
                LicenseCaptureGet viewModel = new LicenseCaptureGet
                {
                    //SelectedCaptureId = captureId,
                    LicenseCaptureList = await _captureRepository.GetLicenseViewByCaptureIdAsync(captureId),
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
