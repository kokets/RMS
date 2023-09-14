using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HSRC_RMS.Controllers
{
    public class MoUManage1EditController : Controller
    {
        private readonly IRepository<MouCreate> _moucreateRepository;

        public MoUManage1EditController(IRepository<MouCreate> moucreateRepository)
        {
            _moucreateRepository = moucreateRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index(int CreateId)
        {
            try
            {
                MouCreate mou = await _moucreateRepository.GetByIdAsync(CreateId);
                //TempData["CaptureData"] = captures;


                MouCreateEdit mouMode = new MouCreateEdit
                {
                    MouViewEdit = new MouCreate
                    {
                        CreateId = mou.CreateId,
                        AgreementType = mou.AgreementType,
                        Division = mou.Division,

                    },
                    MouCreateId = CreateId
                };


                return View(mouMode);



                //return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
                return View();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile templateFile, IFormFile approvedFormFile,  int id)
        {
        
            try
            {
                if ( id <= 0)
                {
                    Console.WriteLine("Invalid ID: " + id); // Log the ID

                    return BadRequest("Invalid ID");
                }

                if (templateFile == null || approvedFormFile == null || templateFile.Length == 0 || approvedFormFile.Length == 0)
                {
                    return BadRequest("Both templateFile and approvedFormFile are required with content.");
                }

                var existingMou = await _moucreateRepository.GetByIdAsync(id);

                if (existingMou == null)
                {
                    return NotFound();
                }

                var tempName = Path.GetFileName(templateFile.FileName);
                var tempFileExtension = Path.GetExtension(tempName);
                var newTempName = String.Concat(Guid.NewGuid(), tempFileExtension);

                var approvedName = Path.GetFileName(approvedFormFile.FileName);
                var approvedFileExtension = Path.GetExtension(approvedName);
                var newApprovedName = String.Concat(Guid.NewGuid(), approvedFileExtension);

                using (var tempMemoryStream = new MemoryStream())
                using (var approvedMemoryStream = new MemoryStream())
                {
                    await templateFile.CopyToAsync(tempMemoryStream);
                    await approvedFormFile.CopyToAsync(approvedMemoryStream);

                    existingMou.FirstName = newTempName;
                    existingMou.SecondName = newApprovedName;
                    existingMou.FirstFileType = tempFileExtension;
                    existingMou.SecondFileType = approvedFileExtension;
                    existingMou.FirstContent = tempMemoryStream.ToArray();
                    existingMou.SecondContent = approvedMemoryStream.ToArray();
                }

                await _moucreateRepository.UpdateAsync(existingMou);
                await _moucreateRepository.SaveAsync();

                return RedirectToAction("Index", "MoUManage1");

                //if (!id.HasValue || id > 0)
                //{
                //    if (templateFile != null && approvedFormFile != null)
                //    {
                //        if (templateFile.Length > 0 && approvedFormFile.Length > 0)
                //        {
                //            var tempName = Path.GetFileName(templateFile.FileName);
                //            var tempFileExtension = Path.GetExtension(tempName);
                //            var newTempName = String.Concat(Guid.NewGuid(), tempFileExtension);


                //            var approvedName = Path.GetFileName(approvedFormFile.FileName);
                //            var approvedFileExtension = Path.GetExtension(approvedName);
                //            var newApprovedName = String.Concat(Guid.NewGuid(), approvedFileExtension);


                //            var doc = new MouCreate
                //            {
                //                //DocumentId = Guid.NewGuid().ToString(), // Assign a unique value
                //                CreateId = id.Value,
                //                FirstName = newTempName,
                //                SecondName = newApprovedName,
                //                FirstFileType = tempFileExtension,
                //                SecondFileType = approvedFileExtension,

                //            };

                //            using (var memoryStream = new MemoryStream())
                //            {
                //                await templateFile.CopyToAsync(memoryStream);
                //                doc.FirstContent = memoryStream.ToArray();
                //                memoryStream.Seek(0, SeekOrigin.Begin); // Reset the stream position
                //                doc.SecondContent = memoryStream.ToArray();

                //            }

                //            var existingMou =await  _moucreateRepository.GetByIdAsync(id.Value);
                //            if(existingMou != null)
                //            {
                //                // Update the existing entity with the new values
                //                existingMou.FirstName = doc.FirstName;
                //                existingMou.SecondName = doc.SecondName;
                //                existingMou.FirstFileType = doc.FirstFileType;
                //                existingMou.SecondFileType = doc.SecondFileType;
                //                existingMou.FirstContent = doc.FirstContent;
                //                existingMou.SecondContent = doc.SecondContent;

                //                // Update the entity in the repository
                //                await _moucreateRepository.UpdateAsync(existingMou);
                //            }
                //            else
                //            {
                //                // Entity with the provided 'id' does not exist, handle accordingly
                //                return NotFound();
                //            }

                //            //await _moucreateRepository.AddAsync(doc);
                //            await _moucreateRepository.SaveAsync();
                //            return RedirectToAction("Index", "MoUManage1"); // Redirect to a suitable action after successful upload

                //        }

                //    }
                //    else
                //    {
                //        // Handle the case where 'id' is null or not a valid integer
                //        return BadRequest("Invalid ID");
                //    }
                //}
                //return View();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index"); // Redirect to a suitable action on error
            }
        }
       
    }
}
