using HSRC_RMS.Helpers;
using HSRC_RMS.Models;
using Microsoft.AspNetCore.Mvc;

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

                List<LicenseCapture> captures = await _captureRepository.GetLicenseViewByCaptureIdAsync(captureId);
                LicenseCaptureGet viewModel = new LicenseCaptureGet
                {
                    LicenseCaptureList = captures,
                    NewLicenseCapture = new LicenseCapture(),
                        CaptureId = captureId // Set the CaptureId property

                };

                //LicenseCaptureGet viewModel = new LicenseCaptureGet
                //{
                //    LicenseCaptureList = await _captureRepository.GetLicenseViewByCaptureIdAsync(captureId),
                //    NewLicenseCapture = new LicenseCapture()
                //};

                //  Update select options
                //viewModel.UsersOptionAsync = await _userRepository.UsersOptionAsync();
                //viewModel.TypeOptionsAsync = await _typeRepository.TypeOptionsAsync();
                //viewModel.SupplierOptionsAsync = await _supplyRepository.SupplierOptionsAsync();

                return View(captures);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LicenseCaptureGet model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var LicenseToUpdate = await _captureRepository.GetByIdAsync(model.NewLicenseCapture.CaptureId);
                    if (LicenseToUpdate == null)
                    {
                        TempData["ErrorMessage"] = "License Type not found.";
                        return NotFound();
                    }

                    // Update properties from the model
                    LicenseToUpdate.LicenseOwner = model.NewLicenseCapture.LicenseOwner;
                    LicenseToUpdate.ProductName = model.NewLicenseCapture.ProductName;
                    LicenseToUpdate.ProductKey = model.NewLicenseCapture.ProductKey;
                    LicenseToUpdate.LicenseType = model.NewLicenseCapture.LicenseType;
                    LicenseToUpdate.AcquiredDate = model.NewLicenseCapture.AcquiredDate;
                    LicenseToUpdate.ExpiryDate = model.NewLicenseCapture.ExpiryDate;
                    LicenseToUpdate.Activations = model.NewLicenseCapture.Activations;
                    LicenseToUpdate.LicenseStatus = model.NewLicenseCapture.LicenseStatus;
                    LicenseToUpdate.Supplier = model.NewLicenseCapture.Supplier;
                    LicenseToUpdate.PurchasePrice = model.NewLicenseCapture.PurchasePrice;
                    LicenseToUpdate.CommentPrice = model.NewLicenseCapture.CommentPrice;

                    _captureRepository.Update(LicenseToUpdate);
                    await _captureRepository.SaveAsync(); // Assuming SaveAsync is the asynchronous method

                    TempData["SuccessMessage"] = "License Type updated successfully.";
                    return RedirectToAction("Index", "LicenseMLTypes"); // Redirect with success message
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
