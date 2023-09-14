using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HSRC_RMS.Controllers
{
    public class MoUViewRequestController : Controller
    {

        private readonly IRepository<MouCreate> _moucreateRepository;

        public MoUViewRequestController(IRepository<MouCreate> moucreateRepository)
        {
            _moucreateRepository = moucreateRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Index(int CreateId)
        {
            try
            {
                MouCreate mou = await _moucreateRepository.GetByIdAsync(CreateId);
                //TempData["CaptureData"] = captures;


                MoUViewRequest mouModel = new MoUViewRequest
                {
                    MouViewRequestById = new MouCreate
                    {
                        CreateId = mou.CreateId,
                        ReferenceNumber = mou.ReferenceNumber,
                        Requester = mou.Requester,
                        AgreementType = mou.AgreementType,
                        MouRequest = mou.MouRequest,
                        Division = mou.Division,
                    },
                    MouCreateId = CreateId
                };


                return View(mouModel);



                //return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
                return View();
            }

        }
    }
}
