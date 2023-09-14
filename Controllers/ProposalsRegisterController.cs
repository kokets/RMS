using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class ProposalsRegisterController : Controller
    {
        private readonly IRepository<ProposalsRegister> _giftRepository;
        //private readonly IRepository<GiftComment> _commentRepository;

        public ProposalsRegisterController(IRepository<ProposalsRegister> giftRepository)
        {
            _giftRepository = giftRepository;
            //_commentRepository = commentRepository;
        }

        public IActionResult Index()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ProposalsRegister model)
        {

            Random random = new Random();

            // Generate a random integer between 1 and 100 (inclusive)
            int randomNumber = random.Next(1, 10000);

            int hardcodedUserId = 1;
            model.UserId = hardcodedUserId;
            model.opportunityId = randomNumber;
            if (ModelState.IsValid)
            {
                try
                {
                    // Hardcoded user ID for testing
                    

                    //add the gift
                    _giftRepository.Add(model);
                    _giftRepository.Save();

                    //add the default comment
                    //var defaultComment = new GiftComment
                    //{
                    //    GiftId = model.GiftId,
                    //    Comment = "Not Submitted to ERM"
                    //};

                    //_commentRepository.Add(defaultComment);
                    //_commentRepository.Save();

                    TempData["SuccessMessage"] = "Gift registered successfully.";

                    return RedirectToAction("Index","ProposalsDisplay");
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
