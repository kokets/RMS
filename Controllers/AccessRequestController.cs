using HSRC_RMS.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class AccessRequestController : Controller
    {
        private readonly ILogger<AccessRequestController> _logger;

        public AccessRequestController(ILogger<AccessRequestController> logger)
        {
            _logger = logger;
        }

        public IActionResult SendEmail()
        {
            // Create a new email message
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Tester", "eladio52@ethereal.email"));
            message.To.Add(MailboxAddress.Parse("email@gmail.com"));
            message.Subject = "Subject";
            message.Body = new TextPart("plain")
            {
                Text = "This email is requsting access for the module"
            };

            // Configure the SMTP client
            SmtpClient client = new SmtpClient();
            try
            {
                client.CheckCertificateRevocation = false;
                client.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
                client.Authenticate("dayana.parisian58@ethereal.email", "hQxm5z6shpz8WU9TnD");
                client.Send(message);

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            return View();
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