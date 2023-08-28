using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Login(Users model)
        {
            if (Login(model.Username, model.Password))
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }

        private bool Login(string username, string password)
        {
            // TODO: Replace this with a more secure storage mechanism (e.g. hashing and salting)
            Dictionary<string, string> users = new Dictionary<string, string>()
        {
            { "alice", "password1" },
            { "bob", "password2" },
            { "charlie", "password3" }
        };

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            if (users.TryGetValue(username, out string storedPassword))
            {
                if (password == storedPassword)
                {
                    // Successful login
                    return true;
                }
            }
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            // Invalid username or password
            return false;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}