using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class GiftRegisterController : Controller
    {
        private readonly IRepository<OpportunitiesRegister> _giftRepository;
        //private readonly IRepository<GiftComment> _commentRepository;

        public GiftRegisterController(IRepository<OpportunitiesRegister> giftRepository)
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
<<<<<<< HEAD
        public IActionResult Index(OpportunitiesRegister model)
=======
        public async Task<IActionResult> Index(GiftRegister model)
>>>>>>> 895b5587976a042806091964f353211f599442ce
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
<<<<<<< HEAD
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
=======
                    // Retrieve the UserId from the session
                    int? userId = HttpContext.Session.GetInt32("UserId");

                    if (userId.HasValue)
                    {
                        model.UserId = userId.Value;
                        Console.WriteLine($"UserId: {model.UserId}");

                        // Add the gift
                       await  _giftRepository.AddAsync(model);
                      await  _giftRepository.SaveAsync();
>>>>>>> 895b5587976a042806091964f353211f599442ce

                        // Add the default comment
                        var defaultComment = new GiftComment
                        {
                            GiftId = model.GiftId,
                            Comment = "Not Submitted to ERM"
                        };

                        await  _commentRepository.AddAsync(defaultComment);
                        await  _commentRepository.SaveAsync();

                        TempData["SuccessMessage"] = "Gift registered successfully.";

                        return RedirectToAction("Index", "GiftDisplay");
                    }
                    else
                    {
                        // Handle the case where UserId is not found in the session
                        ModelState.AddModelError("", "User information not found. Please log in.");
                        return RedirectToAction("Index", "Login");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");

                    ModelState.AddModelError("", "An error occurred while saving the gift.");
                }
            }

            return View(model);
        }
    }
}
