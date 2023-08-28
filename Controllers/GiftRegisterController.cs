using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class GiftRegisterController : Controller
    {
        private readonly IRepository<GiftRegister> _giftRepository;
        private readonly IRepository<GiftComment> _commentRepository;

        public GiftRegisterController(IRepository<GiftRegister> giftRepository, IRepository<GiftComment> commentRepository)
        {
            _giftRepository = giftRepository;
            _commentRepository = commentRepository;
        }

        public IActionResult Index()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(GiftRegister model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Hardcoded user ID for testing
                    int hardcodedUserId = 1;
                    model.UserId = hardcodedUserId;

                    //add the gift
                    _giftRepository.Add(model);
                    _giftRepository.Save();

                    //add the default comment
                    var defaultComment = new GiftComment
                    {
                        GiftId = model.GiftId,
                        Comment = "Not Submitted to ERM"
                    };

                    _commentRepository.Add(defaultComment);
                    _commentRepository.Save();

                    TempData["SuccessMessage"] = "Gift registered successfully.";

                    return RedirectToAction("Index","GiftDisplay");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "An error occurred while saving the gift.");
                }
            }

            return View(model);
        }
    }
}
