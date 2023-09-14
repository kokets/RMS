using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class MoUViewController : Controller
    {
        private readonly IRepository<MouCreate> _moucreateRepository;
        private readonly IRepository<Users> _userRepository;

        public MoUViewController(IRepository<MouCreate> moucreateRepository, IRepository<Users> userRepository)
        {
            _moucreateRepository = moucreateRepository;
            _userRepository = userRepository;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}


        [HttpGet]
        public IActionResult Index()
        {
            var mouList = _moucreateRepository.GetAll()
                    .Select(mou => new MouCreate
                    {
                        CreateId = mou.CreateId,

                        Requester = mou.Requester,
                        ReferenceNumber = mou.ReferenceNumber,
                        MouRequest = mou.MouRequest,
                        Division = mou.Division,
                        AgreementType = mou.AgreementType,
                        DateCapture = mou.DateCapture,
                    })
                    .ToList();

            return View(mouList);
        }
    }
}
