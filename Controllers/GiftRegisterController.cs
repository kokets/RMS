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

        public async Task<IActionResult> Index(GiftRegister model)
        {


       
            if (ModelState.IsValid)
            {
                try
                {


                    // Retrieve the UserId from the session
                    int? userId = HttpContext.Session.GetInt32("UserId");

                    if (userId.HasValue)
                    {
                        model.UserId = userId.Value;
                        Console.WriteLine($"UserId: {model.UserId}");

                        // Add the gift
                       await  _giftRepository.AddAsync(model);
                      await  _giftRepository.SaveAsync();
                    // Add the default comment
                    var defaultComment = new GiftComment
                    {
                        GiftId = model.GiftId,
                        Comment = "Not Submitted to ERM"
                    };

                    await _commentRepository.AddAsync(defaultComment);
                    await _commentRepository.SaveAsync();

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
