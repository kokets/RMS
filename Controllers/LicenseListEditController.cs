using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
namespace HSRC_RMS.Controllers
{
    public class LicenseListEditController : Controller
    {
        private readonly IRepository<LicenseCapture> _captureRepository;
        private readonly IRepository<LicenseSupplies> _supplyRepository;
        private readonly IRepository<LicenseType> _typeRepository;
        private readonly IRepository<Users> _userRepository;

        public LicenseListEditController(IRepository<LicenseCapture> captureRepository, IRepository<LicenseSupplies> supplyRepository, IRepository<LicenseType> typeRepository, IRepository<Users> userRepository)
        {
            _captureRepository = captureRepository;
            _supplyRepository = supplyRepository;
            _userRepository = userRepository;
            _typeRepository = typeRepository;


        }

        [HttpGet]
        public async Task<IActionResult> Index(int captureId)
        {
            try
            {

                LicenseCapture capture = await _captureRepository.GetByIdAsync(captureId);
                //TempData["CaptureData"] = captures;


                LicenseEditGet viewModel = new LicenseEditGet
                {
                    NewEditCapture = new LicenseCapture
                    {
                        LicenseOwner = capture.LicenseOwner,
                        ProductName = capture.ProductName,
                        ProductKey = capture.ProductKey,
                        LicenseType = capture.LicenseType,
                        AcquiredDate = capture.AcquiredDate,
                        ExpiryDate = capture.ExpiryDate,
                        Activations = capture.Activations,
                        LicenseStatus = capture.LicenseStatus,
                        Supplier = capture.Supplier,
                        PurchasePrice = capture.PurchasePrice,
                        CommentPrice = capture.CommentPrice
                    },
                    CaptureId = captureId
                };



                //LicenseCaptureGet viewModel = new LicenseCaptureGet
                //{
                //    LicenseCaptureList = await _captureRepository.GetLicenseViewByCaptureIdAsync(captureId),
                //    NewLicenseCapture = new LicenseCapture()
                //};

                //  Update select options
                viewModel.UsersOptionAsync = await _userRepository.UsersOptionAsync();
                viewModel.TypeOptionsAsync = await _typeRepository.TypeOptionsAsync();
                viewModel.SupplierOptionsAsync = await _supplyRepository.SupplierOptionsAsync();

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LicenseEditGet model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var LicenseToUpdate = await _captureRepository.GetByIdAsync(model.NewEditCapture.CaptureId);
                    if (LicenseToUpdate == null)
                    {
                        TempData["ErrorMessage"] = "License  not found.";
                        return NotFound();
                    }

                    // Update properties from the model
                    LicenseToUpdate.LicenseOwner = model.NewEditCapture.LicenseOwner;
                    LicenseToUpdate.ProductName = model.NewEditCapture.ProductName;
                    LicenseToUpdate.ProductKey = model.NewEditCapture.ProductKey;
                    LicenseToUpdate.LicenseType = model.NewEditCapture.LicenseType;
                    LicenseToUpdate.AcquiredDate = model.NewEditCapture.AcquiredDate;
                    LicenseToUpdate.ExpiryDate = model.NewEditCapture.ExpiryDate;
                    LicenseToUpdate.Activations = model.NewEditCapture.Activations;
                    LicenseToUpdate.LicenseStatus = model.NewEditCapture.LicenseStatus;
                    LicenseToUpdate.Supplier = model.NewEditCapture.Supplier;
                    LicenseToUpdate.PurchasePrice = model.NewEditCapture.PurchasePrice;
                    LicenseToUpdate.CommentPrice = model.NewEditCapture.CommentPrice;

                    await _captureRepository.UpdateAsync(LicenseToUpdate);
                    await _captureRepository.SaveAsync(); // Assuming SaveAsync is the asynchronous method

                    TempData["SuccessMessage"] = "License  updated successfully.";
                    return RedirectToAction("Index", "LicenseList"); // Redirect with success message
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "An error occurred while updating the License Type: " + ex.Message;
                    model.UsersOptionAsync = await _userRepository.UsersOptionAsync();
                    model.TypeOptionsAsync = await _typeRepository.TypeOptionsAsync();
                    model.SupplierOptionsAsync = await _supplyRepository.SupplierOptionsAsync();
                    return View(model); // Return to the edit view with error message
                }
            }
            else
            {
                // Collect validation errors
                var validationErrors = ModelState.Values.SelectMany(v => v.Errors)
                                                         .Select(e => e.ErrorMessage)
                                                         .ToList();

                // Store validation errors in TempData
                TempData["ValidationErrors"] = validationErrors;
            }
            // If ModelState is not valid, populate dropdown options and return to the edit view with the model
            model.UsersOptionAsync = await _userRepository.UsersOptionAsync();
            model.TypeOptionsAsync = await _typeRepository.TypeOptionsAsync();
            model.SupplierOptionsAsync = await _supplyRepository.SupplierOptionsAsync();
            return View(model);
        }


        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    var licenseCaptureGet = new LicenseCaptureGet();

        //    licenseCaptureGet.UsersOptionAsync = await _userRepository.UsersOptionAsync();
        //    licenseCaptureGet.TypeOptionsAsync = await _typeRepository.TypeOptionsAsync();
        //    licenseCaptureGet.SupplierOptionsAsync = await _supplyRepository.SupplierOptionsAsync();
        //    // Populate other properties if needed
        //    return View(licenseCaptureGet);
        //}
        //[HttpGet]
        //public async Task<IActionResult> Index(int id)
        //{
        //    var LicenseToEdit = await _captureRepository.GetByIdAsync(id);
        //    if (LicenseToEdit == null)
        //    {
        //        return NotFound();
        //    }

        //    var viewModel = new LicenseCaptureGet();

        //    // Populate dropdown options
        //    //viewModel.usersOption = usersOption();
        //    //viewModel.typeOptions = typeOptions();
        //    //viewModel.supplierOptions = supplierOptions();

        //    // Populate LicenseCapture properties for editing
        //    viewModel.NewLicenseCapture = new LicenseCapture
        //    {
        //        CaptureId = LicenseToEdit.CaptureId,
        //        UserId = LicenseToEdit.UserId,
        //        LicenseOwner = LicenseToEdit.LicenseOwner,
        //        ProductName = LicenseToEdit.ProductName,
        //        ProductKey = LicenseToEdit.ProductKey,
        //        LicenseType = LicenseToEdit.LicenseType,
        //        AcquiredDate = LicenseToEdit.AcquiredDate,
        //        ExpiryDate = LicenseToEdit.ExpiryDate,
        //        Activations = LicenseToEdit.Activations,
        //        LicenseStatus = LicenseToEdit.LicenseStatus,
        //        Supplier = LicenseToEdit.Supplier,
        //        PurchasePrice = LicenseToEdit.PurchasePrice,
        //        CommentPrice = LicenseToEdit.CommentPrice,
        //        User = LicenseToEdit.User // Assuming User is a navigation property
        //    };

        //    return View(viewModel);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Index(LicenseCaptureGet model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var licenseToEdit = await _captureRepository.GetByIdAsync(model.NewLicenseCapture.CaptureId);
        //            if (licenseToEdit == null)
        //            {
        //                TempData["ErrorMessage"] = "License Supply not found.";
        //                return NotFound();
        //            }

        //            // Update the properties from the model
        //            licenseToEdit.LicenseOwner = model.NewLicenseCapture.LicenseOwner;
        //            licenseToEdit.ProductName = model.NewLicenseCapture.ProductName;
        //            licenseToEdit.ProductKey = model.NewLicenseCapture.ProductKey;
        //            licenseToEdit.LicenseType = model.NewLicenseCapture.LicenseType;
        //            licenseToEdit.AcquiredDate = model.NewLicenseCapture.AcquiredDate;
        //            licenseToEdit.ExpiryDate = model.NewLicenseCapture.ExpiryDate;
        //            licenseToEdit.Activations = model.NewLicenseCapture.Activations;
        //            licenseToEdit.LicenseStatus = model.NewLicenseCapture.LicenseStatus;
        //            licenseToEdit.Supplier = model.NewLicenseCapture.Supplier;
        //            licenseToEdit.PurchasePrice = model.NewLicenseCapture.PurchasePrice;
        //            licenseToEdit.CommentPrice = model.NewLicenseCapture.CommentPrice;

        //            _captureRepository.Update(licenseToEdit);
        //            await _captureRepository.SaveAsync();

        //            TempData["SuccessMessage"] = "License Supply updated successfully.";
        //            return RedirectToAction("Index", "LicenseMSupplier"); // Redirect with success message
        //        }
        //        catch (Exception ex)
        //        {
        //            TempData["ErrorMessage"] = "An error occurred while updating the License Supply: " + ex.Message;
        //            return View(model); // Return to the edit view with error message
        //        }
        //    }

        //    // If ModelState is not valid, return to the edit view with the model
        //    return View(model);
        //}

    }
}
