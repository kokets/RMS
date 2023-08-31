using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class MoUCreateController : Controller
    {
        private readonly IRepository<MouCreate> _moucreateRepository;
        private readonly IRepository<Users> _userRepository;

        public MoUCreateController(IRepository<MouCreate> moucreateRepository, IRepository<Users> userRepository)
        {
            _moucreateRepository = moucreateRepository;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public  async Task<IActionResult> Index ()
        //{

        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Index(MouCreate model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            // Hardcoded user ID for testing
        //            int hardcodedUserId = 1;
        //            model.UserId = hardcodedUserId;

        //            // Add the gift asynchronously
        //            await _moucreateRepository.AddAsync(model);
        //            await _moucreateRepository.SaveAsync();

        //            TempData["SuccessMessage"] = "Gift registered successfully.";

        //            return RedirectToAction("Index", "MoUManage1");
        //        }
        //        catch (Exception)
        //        {
        //            ModelState.AddModelError("", "An error occurred while saving the gift.");
        //        }
        //    }

        //    return View(model);
        //}

    }
}
