using Microsoft.AspNetCore.Mvc;

namespace HSRC_RMS.Controllers
{
    public class MoUViewRequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
