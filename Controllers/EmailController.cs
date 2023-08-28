using HSRC_RMS.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class EmailController : Controller
    {
        private readonly ILogger<EmailController> _logger;

        public EmailController(ILogger<EmailController> logger)
        {
            _logger = logger;
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

        [HttpPost]


        public IActionResult SendEmail(string senderEmail, string senderPassword, string recipientEmail, string subject, string body)
        {
            // Create a new email message
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse("email1@gmail.com"));
            message.To.Add(MailboxAddress.Parse("email@gmail.com"));
            message.Subject = "Subject";
            message.Body = new TextPart("plain")
            {
                Text = body
            };

            // Configure the SMTP client
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("email1@gmail.com", "jsafhabsefa");

                // Send the email
                client.Send(message);
                client.Disconnect(true);
            }

            return Ok();
        }

    }
}