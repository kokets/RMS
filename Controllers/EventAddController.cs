using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;

namespace HSRC_RMS.Controllers
{
    public class EventAddController : Controller
    {
         private readonly IRepository<Event> _eventsRepository;
        private readonly IRepository<EventFiles> _eventsFilesRepository;
        public EventAddController( IRepository<EventFiles> eventsFilesRepository, IRepository<Event> eventsRepository)
        {
            _eventsFilesRepository = eventsFilesRepository;
            _eventsRepository = eventsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(EventCapture model, IFormFile? FirstTemplateFile, IFormFile? SecondTemplateFile, IFormFile? ThirdTemplateFile, IFormFile? FourthTemplateFile, IFormFile? FifthTemplateFile)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    int? userId = HttpContext.Session.GetInt32("UserId");
                    if (!userId.HasValue)
                    {
                        return RedirectToAction(" Index", "Login");
                    }
                    model.NewEvent.UserId = userId.Value;
                    model.NewEvent.SubmissionDate = DateTime.Now;

                    using (var FirstMemoryStream = new MemoryStream())
                    using (var SecondMemoryStream = new MemoryStream())
                    using (var ThirdMemoryStream = new MemoryStream())
                    using (var FourthMemoryStream = new MemoryStream())
                    using (var FifthMemoryStream = new MemoryStream())
                    {

                        if (FirstTemplateFile != null && FirstTemplateFile.Length > 0)
                        {
                            await FirstTemplateFile.CopyToAsync(FirstMemoryStream);
                            model.NewEvent.FirstFileType = Path.GetExtension(FirstTemplateFile.FileName);
                            model.NewEvent.FirstContent = FirstMemoryStream.ToArray();
                        }
                        if (SecondTemplateFile != null && SecondTemplateFile.Length > 0)
                        {
                            await SecondTemplateFile.CopyToAsync(SecondMemoryStream);
                            model.NewEvent.SecondFileType = Path.GetExtension(SecondTemplateFile.FileName);
                            model.NewEvent.SecondContent = SecondMemoryStream.ToArray();
                        }
                        if (ThirdTemplateFile != null && ThirdTemplateFile.Length > 0)
                        {
                            await ThirdTemplateFile.CopyToAsync(ThirdMemoryStream);
                            model.NewEvent.ThirdFileType = Path.GetExtension(ThirdTemplateFile.FileName);
                            model.NewEvent.ThirdContent = ThirdMemoryStream.ToArray();
                        }
                        if (FourthTemplateFile != null && FourthTemplateFile.Length > 0)
                        {
                            await FourthTemplateFile.CopyToAsync(FourthMemoryStream);
                            model.NewEvent.FourthFileType = Path.GetExtension(FourthTemplateFile.FileName);
                            model.NewEvent.FourthContent = FourthMemoryStream.ToArray();
                        }
                        if (FifthTemplateFile != null && FifthTemplateFile.Length > 0)
                        {
                            await FifthTemplateFile.CopyToAsync(FifthMemoryStream);
                                model.NewEvent.FifthFileType = Path.GetExtension(FifthTemplateFile.FileName);
                            model.NewEvent.FifthContent = FifthMemoryStream.ToArray();
                        }
                    }
                    await _eventsRepository.AddAsync(model.NewEvent);
                    await _eventsRepository.SaveAsync();

                    return RedirectToAction("Index", "EventRegistration");
                }
                catch (Exception ex) { 
                }
            }
            else
            {
                Console.WriteLine("Model is not valid. Validation errors:");

                foreach (var key in ModelState.Keys)
                {
                    foreach (var error in ModelState[key].Errors)
                    {
                        Console.WriteLine("Property: " + key + ", Error: " + error.ErrorMessage);
                    }
                }
            }
            return View(model);
        }


         
    }
}
