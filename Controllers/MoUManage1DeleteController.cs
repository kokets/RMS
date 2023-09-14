using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class MoUManage1DeleteController : Controller
    {
        private readonly IRepository<MouCreate> _moucreateRepository;

        public MoUManage1DeleteController(IRepository<MouCreate> moucreateRepository )
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


                MouCreateDelete mouMode = new MouCreateDelete
                {
                    MouViewDelete = new MouCreate
                    {
                        CreateId = mou.CreateId,
                        ReferenceNumber = mou.ReferenceNumber,
                        AgreementType = mou.AgreementType,
                        MouRequest = mou.MouRequest,
                        Division = mou.Division,
                        
                    },
                    MouCreateId = CreateId
                };


                return View(mouMode);
               


                //return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
                return View();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int creatId)
        {
            try
            {
                Console.WriteLine(creatId);

                await _moucreateRepository.DeleteByCreateIdAsync(creatId);

                return RedirectToAction("Index", "MoUManage1");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index", "MoUManage1Delete");

            }


        }
    }
}
