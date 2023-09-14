using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace HSRC_RMS.Controllers
{
    public class EventRegistrationController : Controller
    {
        private readonly IRepository<Event> _eventsRepository;
        private readonly IRepository<EventFiles> _eventsFilesRepository;
        private readonly RmsDbConnect _dbConnect;

        public EventRegistrationController(IRepository<EventFiles> eventsFilesRepository, IRepository<Event> eventsRepository, RmsDbConnect dbConnect)
        {
            _eventsFilesRepository = eventsFilesRepository;
            _eventsRepository = eventsRepository;
            _dbConnect = dbConnect;

        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                int? userId = HttpContext.Session.GetInt32("UserId");
                if (!userId.HasValue)
                {
                    return RedirectToAction("Index", "Login");
                }

                List<Event> eventList = await _eventsRepository.GetEvents();
                foreach (var events in eventList)
                {
                    Console.WriteLine($"Type: {events.EventType}");
                    Console.WriteLine($"Title: {events.Title}");
                    Console.WriteLine($"Sub Date: {events.SubmissionDate}");
                    Console.WriteLine($"Event Date: {events.EventDate}");

                    // Output other properties as needed

                    Console.WriteLine(); // Add a blank line for separation
                }
                EventCapture capturedEvent = new EventCapture
                {
                    EventList = eventList, 
                };
                return View(capturedEvent);
            }
            catch (Exception ex)
            {
                return View();

            }

        }


        [HttpGet]
        public async Task<IActionResult> DownloadFirstPdf( int eventId)
        {
            // Retrieve the LicenseActivation by ID
            var firstPDF = await _dbConnect.Event
                .Where(events => events.EventId == eventId)
                .FirstOrDefaultAsync();

            if (firstPDF == null)
            {
                return NotFound(); // Handle not found case
            }

            // Assuming you have a property in LicenseActivation for the PDF content
            // Replace 'PdfContent' with the actual property name in your model
            var pdfContent = firstPDF.FirstContent;

            if (pdfContent == null)
            {
                Console.WriteLine("No pdf content");
                return NotFound(); // Handle missing PDF content
            }

            // Return the PDF file as a downloadable file
            return File(pdfContent, "application/pdf", "First.pdf");
        }


        [HttpGet]
        public async Task<IActionResult> DownloadSecondPdf( int eventId)
        {
            // Retrieve the LicenseActivation by ID
            var SecondPDF = await _dbConnect.Event
                .Where(events => events.EventId == eventId)
                .FirstOrDefaultAsync();

            if (SecondPDF == null)
            {
                return NotFound(); // Handle not found case
            }

            // Assuming you have a property in LicenseActivation for the PDF content
            // Replace 'PdfContent' with the actual property name in your model
            var pdfContent = SecondPDF.SecondContent;

            if (pdfContent == null)
            {
                return NotFound(); // Handle missing PDF content
            }

            // Return the PDF file as a downloadable file
            return File(pdfContent, "application/pdf", "Second.pdf");
        }


        [HttpGet]
        public async Task<IActionResult> DownloadThirdPdf( int eventId)
        {
            // Retrieve the LicenseActivation by ID
            var thirdPDF = await _dbConnect.Event
                .Where(events =>  events.EventId == eventId)
                .FirstOrDefaultAsync();

            if (thirdPDF == null)
            {
                return NotFound(); // Handle not found case
            }

            // Assuming you have a property in LicenseActivation for the PDF content
            // Replace 'PdfContent' with the actual property name in your model
            var pdfContent = thirdPDF.ThirdContent;

            if (pdfContent == null)
            {
                return NotFound(); // Handle missing PDF content
            }

            // Return the PDF file as a downloadable file
            return File(pdfContent, "application/pdf", "Third.pdf");
        }


        [HttpGet]
        public async Task<IActionResult> DownloadFourthPdf( int eventId)
        {
            // Retrieve the LicenseActivation by ID
            var fourthPDF = await _dbConnect.Event
                .Where(events =>  events.EventId == eventId)
                .FirstOrDefaultAsync();

            if (fourthPDF == null)
            {
                return NotFound(); // Handle not found case
            }

            // Assuming you have a property in LicenseActivation for the PDF content
            // Replace 'PdfContent' with the actual property name in your model
            var pdfContent = fourthPDF.FourthContent;

            if (pdfContent == null)
            {
                return NotFound(); // Handle missing PDF content
            }

            // Return the PDF file as a downloadable file
            return File(pdfContent, "application/pdf", "Fourth.pdf");
        }


        [HttpGet]
        public async Task<IActionResult> DownloadFifthPdf( int eventId)
        {
            // Retrieve the LicenseActivation by ID
            var fifthPDF = await _dbConnect.Event
                .Where(events =>  events.EventId == eventId)
                .FirstOrDefaultAsync();

            if (fifthPDF == null)
            {
                return NotFound(); // Handle not found case
            }

            // Assuming you have a property in LicenseActivation for the PDF content
            // Replace 'PdfContent' with the actual property name in your model
            var pdfContent = fifthPDF.FifthContent;

            if (pdfContent == null)
            {
                return NotFound(); // Handle missing PDF content
            }

            // Return the PDF file as a downloadable file
            return File(pdfContent, "application/pdf", "Fifth.pdf");
        }
    }
}
