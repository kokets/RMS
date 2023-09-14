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
        //public async Task<IActionResult> Index()
        //{
        //    int hardcoded = 1;

        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(MouCreate model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int? userId = HttpContext.Session.GetInt32("UserId");
                    if (userId.HasValue)
                    {

                        //model.UserId = userId.Value;
                        Console.WriteLine($"UserId: {model.UserId}");
                        //model.DateCapture = DateTime.Now;

                        var moU = new MouCreate
                        {
                            UserId = userId.Value,
                            Division = model.Division,
                            Requester = model.Requester,
                            ContactDetails = model.ContactDetails,
                            MouRequest = model.MouRequest,
                            AgreementType = model.AgreementType,
                            PartnerName = model.PartnerName,
                            InstitutionType = model.InstitutionType,
                            MouPurpose = model.MouPurpose,
                            DateCapture = DateTime.Now,
                            ReferenceNumber = model.ReferenceNumber,
                        };

                        // Add the gift asynchronously
                        await _moucreateRepository.AddAsync(moU);
                        await _moucreateRepository.SaveAsync();


                        return RedirectToAction("Index", "MoUManage1");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Login");

                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "An error occurred while saving the gift.");
                }
            }
            else
            {
                Console.WriteLine("Model is not valid. Validation errors:");

                foreach (var key in ModelState.Keys)
                {
                    foreach (var error in ModelState[key].Errors)
                    {
                        Console.WriteLine("Property: " + key + ", Error: " + error.ErrorMessage);
                    }
                }
            }

            return View(model);
        }
        public string GenerateMouReference()
        {
            // Generate a timestamp as part of the reference
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");

            // Generate a unique identifier (UUID)
            string uniqueId = Guid.NewGuid().ToString("N");

            // Combine the prefix, timestamp, and unique identifier
            string reference = "MOU-" + timestamp + "-" + uniqueId;

            return reference;
        }


    }
}
