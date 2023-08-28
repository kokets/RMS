using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class GiftDisplayController : Controller
    {


        private readonly IRepository<GiftRegister> _giftRepository;
        private readonly IRepository<Users> _usersRepository;
        private readonly IRepository<GiftComment> _commentRepository;

        private readonly RmsDbConnect  _context;

        public GiftDisplayController(IRepository<GiftRegister> giftRepository, IRepository<Users> usersRepository, RmsDbConnect context, IRepository<GiftComment> commentRepository)
        {
            _giftRepository = giftRepository;
            _usersRepository = usersRepository;
            _commentRepository = commentRepository;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var giftDisplayList = _giftRepository.GetAll()
                    .Select(gift => new GiftDisplay
                    {
                        GiftId = gift.GiftId,
                        UserName = _usersRepository.FindBy(user => user.UserId == gift.UserId)
                            .Select(user => user.Username)
                            .FirstOrDefault(),
                        GiftSponsor = gift.GiftSponsor,
                        GiftOrganization = gift.GiftOrganization,
                        NatureOfBusiness = gift.NatureOfBusiness,
                        GiftDescription = gift.GiftDescription,
                        Value = gift.Value,
                        PurposeOfGift = gift.PurposeOfGift,
                        ReceivedInAppreciation = gift.ReceivedInAppreciation,
                        CurrentDate = DateTime.Now,
                          //fetch the comment associated with the giftid

                          Comment = _commentRepository.FindBy(comment => comment.GiftId == gift.GiftId)
                            .Select(comment => comment.Comment)
                            .FirstOrDefault(),
                    })
                    .ToList();

            return View(giftDisplayList);
        }

        [HttpPost]
        public IActionResult Index(int giftId)
        {
            var giftComment = _commentRepository.FindBy(comment => comment.GiftId == giftId).FirstOrDefault();
            if (giftComment != null)
            {
                giftComment.Comment = "Submitted ERM"; // Update the comment
                _commentRepository.Update(giftComment);
                _commentRepository.Save();
            }
       
            return RedirectToAction("Index", "GiftDisplay");
        }
    }
}
