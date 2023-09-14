using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class MoUManage1Controller : Controller
    {
        private readonly IRepository<MouCreate> _moucreateRepository;
        private readonly IRepository<Users> _userRepository;

        public MoUManage1Controller(IRepository<MouCreate> moucreateRepository, IRepository<Users> userRepository)
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
                        DateCapture = mou.DateCapture,
                        ReferenceNumber = mou.ReferenceNumber,
                        MouRequest = mou.MouRequest,
                        Division = mou.Division,

                        AgreementType = mou.AgreementType,
                    
                    })
                    .ToList();

            return View(mouList);
        }
    }
}
