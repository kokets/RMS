using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace HSRC_RMS.Models
{
    public class LicenseSupplies
    {
        [Key]
        public int SupplierId { get; set; }
        [Required]
        public int UserId { get; set; }
        public Users? User { get; set; }
        [Required, StringLength(50)]
        public string Supplier { get; set; }
        [Required,]
        public int Contact { get; set; }
        [Required,StringLength(50)]
        public string EmailAddress { get; set; }
        [Required, StringLength(20)]
        public string  Status { get; set; }

    }

    public class LicenseSuppliesGet
    {
        public List<LicenseSupplies> LicenseSupplyList { get; set; }
        public LicenseSupplies NewLicenseSupply { get; set; }
    }


    public class LicenseType
    {
        [Key]
        public int TypeId { get; set; }
        [Required]
        public int UserId { get; set; }
        public Users? User { get; set; }
        [Required, StringLength(50)]
        public string Type { get; set; }
        [Required, StringLength(20)]
        public string Status { get; set; }

    }

    public class LicenseTypeGet
    {
        public List<LicenseType> LicenseTypeList { get; set; }
        public LicenseType NewLicenseType { get; set; }
    }



    public class LicenseCapture
    {
        [Key]
        public int CaptureId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required, StringLength(100)]
        public string LicenseOwner { get; set; }

        [Required, StringLength(100)]
        public string ProductName { get; set; }

        [Required, StringLength(100)]
        public string ProductKey { get; set; }

        [Required, StringLength(50)]
        public string LicenseType { get; set; }

        [Required]
        [Column(TypeName = "date")] // Specify the SQL Server DATE type

        public DateTime AcquiredDate { get; set; }

        [Required]
        [Column(TypeName = "date")] // Specify the SQL Server DATE type

        public DateTime ExpiryDate { get; set; }

        [Required]
        public int Activations { get; set; }

        [Required, StringLength(20)]
        public string LicenseStatus { get; set; }

        [Required, StringLength(20)]
        public string Supplier { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")] // Specifies the decimal format
        public decimal PurchasePrice { get; set; }

        [MaxLength] // Unlimited length for CommentPrice
        public string CommentPrice { get; set; }

        [ForeignKey("UserId")]
        public Users? User { get; set; } // Assuming you have a Users model

    }

    public class LicenseCaptureGet
    {
        public List<string> LicenseCSuppliesList { get; set; }
        public List<string> LicenseCUsersList { get; set; }
        public List<string> LicenseCTypeList { get; set; }
        public List<SelectListItem> UsersOptionAsync { get; set; } // New property
        public List<SelectListItem> TypeOptionsAsync { get; set; } // New property
        public List<SelectListItem> SupplierOptionsAsync { get; set; } // New property
    
        public LicenseCapture NewLicenseCapture { get; set; }
        public List<LicenseCapture> LicenseCaptureList { get; set; }
        public int CaptureId { get; set; } // Add this property

        public LicenseCaptureGet()
        {
            LicenseCSuppliesList = new List<string>();
            LicenseCUsersList = new List<string>();
            LicenseCTypeList = new List<string>();
            UsersOptionAsync = new List<SelectListItem>(); // Initialize the list
            TypeOptionsAsync = new List<SelectListItem>(); // Initialize the list
            SupplierOptionsAsync = new List<SelectListItem>(); // Initialize the list
            NewLicenseCapture = new LicenseCapture();
            LicenseCaptureList = new List<LicenseCapture>();
        }
    }

}
