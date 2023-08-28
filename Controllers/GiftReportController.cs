using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class GiftReportController : Controller
    {


        private readonly IRepository<GiftRegister> _giftRepository;
        private readonly IRepository<Users> _usersRepository;
        private readonly IRepository<GiftComment> _commentRepository;

        private readonly RmsDbConnect _context;

        public GiftReportController(IRepository<GiftRegister> giftRepository, IRepository<Users> usersRepository, RmsDbConnect context, IRepository<GiftComment>  commentRepository)
        {
            _giftRepository = giftRepository;
            _usersRepository = usersRepository;
            _context = context;
            _commentRepository = commentRepository;
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
    }
}
