using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class ProposalsDisplayController : Controller
    {


        private readonly IRepository<ProposalsRegister> _giftRepository;
        private readonly IRepository<Users> _usersRepository;
        //private readonly IRepository<GiftComment> _commentRepository;

        private readonly RmsDbConnect  _context;

        public ProposalsDisplayController(IRepository<ProposalsRegister> giftRepository, IRepository<Users> usersRepository, RmsDbConnect context)
        {
            _giftRepository = giftRepository;
            _usersRepository = usersRepository;
            //_commentRepository = commentRepository;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var giftDisplayList = _giftRepository.GetAll()
                   .Select(opportunities => new ProposalsDisplay
                   {
                       opportunityId = opportunities.opportunityId,

                       UserId = opportunities.UserId,
                       Title = opportunities.Title,
                       Funder = opportunities.Funder,
                       Program = opportunities.Program,
                       Status = opportunities.Status,
                       Url = opportunities.Url,
                       SubmissionDate = opportunities.SubmissionDate,
                   })
                   .ToList();

            return View(giftDisplayList);
        }

        //[HttpPost]
        //public IActionResult Index(int giftId)
        //{
        //    var giftComment = _commentRepository.FindBy(comment => comment.GiftId == giftId).FirstOrDefault();
        //    if (giftComment != null)
        //    {
        //        giftComment.Comment = "Submitted ERM"; // Update the comment
        //        _commentRepository.Update(giftComment);
        //        _commentRepository.Save();
        //    }
       
        //    return RedirectToAction("Index", "GiftDisplay");
        //}
    }
}
