using Microsoft.AspNetCore.Mvc;

namespace HSRC_RMS.Controllers
{
    public class DatasetDocumentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
