using Microsoft.AspNetCore.Mvc;

namespace HSRC_RMS.Controllers
{
    public class DatasetCollectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
