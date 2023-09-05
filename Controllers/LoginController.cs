
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HSRC_RMS.Controllers
{
    public class LoginController : Controller
    {
        private readonly RmsDbConnect _dbContext;

        public LoginController(RmsDbConnect dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Users model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await AuthenticateUserAsync(model);

                    if (user != null)
                    {
                        // Set UserId and RoleName based on authentication
                        HttpContext.Session.SetString("Username", model.Username);
                        HttpContext.Session.SetInt32("UserId", user.UserId);
                        HttpContext.Session.SetString("RoleName", user.RoleName);


                        Console.WriteLine($"UserId: {user.UserId}, Username: {model.Username}, RoleName: {user.RoleName}");


                        // Redirect to a secured area
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid Username or password");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                    ModelState.AddModelError(string.Empty, "An error occurred during login.");
                }
            }
            return View(model);
        }

        private async Task<Users> AuthenticateUserAsync(Users model)
        {
            try
            {
                // Implement your authentication logic using Entity Framework Core
                var user =await  _dbContext.Users
                    .Where(u => u.Username == model.Username && u.Password == model.Password)
                    .FirstOrDefaultAsync();

                // Log user and query for debugging
                Console.WriteLine($"User: , Query: {model.Username} - {model.Password}");

                return user; // This may be null if no user is found, indicating authentication failure.
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur during authentication
                Console.WriteLine($"Authentication Error: {ex.Message}");
                throw; // Rethrow the exception for further analysis
            }
        }
    }
}
