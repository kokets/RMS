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
                LicenseCapture captureView = await _captureRepository.GetByIdAsync(captureId);
                //TempData["CaptureData"] = captures;


                LicenseViewGet viewModel = new LicenseViewGet
                {
                    NewViewLicense = new LicenseCapture
                    {
                        LicenseOwner = captureView.LicenseOwner,
                        ProductName = captureView.ProductName,
                        ProductKey = captureView.ProductKey,
                        LicenseType = captureView.LicenseType,
                        AcquiredDate = captureView.AcquiredDate,
                        ExpiryDate = captureView.ExpiryDate,
                        Activations = captureView.Activations,
                        LicenseStatus = captureView.LicenseStatus,
                        Supplier = captureView.Supplier,
                        PurchasePrice = captureView.PurchasePrice,
                        CommentPrice = captureView.CommentPrice
                    },
                    CaptureId = captureId
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
