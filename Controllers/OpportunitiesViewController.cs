using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace HSRC_RMS.Controllers
{
    public class OpportunitiesViewController : Controller
    {
        private readonly IRepository<OpportunitiesRegister> _captureRepository;

        public OpportunitiesViewController(IRepository<OpportunitiesRegister> captureRepository)
        {
            _captureRepository = captureRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int captureId)
        {
            try
            {
                OpportunitiesRegister captureView = await _captureRepository.GetByIdAsync(captureId);
                //TempData["CaptureData"] = captures;


                OpportunitiesViewGet viewModel = new OpportunitiesViewGet
				{
                    NewViewLicense = new OpportunitiesRegister
					{
						opportunityId = captureView.opportunityId,

						UserId = captureView.UserId,
						Title = captureView.Title,
						Funder = captureView.Funder,
						Program = captureView.Program,
						Status = captureView.Status,
						Url = captureView.Url,
						SubmissionDate = captureView.SubmissionDate,
					},
					opportunityId = captureId
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
