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
        public DateTime AcquiredDate { get; set; }
     

        [Required]
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
    public class LicenseActivation
    {
        [Key]
        public int ActivationId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required, StringLength(100)]
        public string LicenseUser { get; set; }

        [Required]
        private DateTime _acquirecdDate;
        public DateTime ActivationDate { 
            get { return _acquirecdDate.Date; }
            set { _acquirecdDate = value.Date; }
        }

        [Required]
        private DateTime _expiryDate;
        public DateTime ExpiryDate
        {
            get { return _expiryDate.Date; } // Extracts date part, time is avoided
            set { _expiryDate = value.Date; } // Sets only the date part, time is ignored
        }

        [Required]
        public byte[] AccessFile { get; set; }

        // Navigation property to represent the User
        public Users? User { get; set; }
    }
  
    public class LicenseActivationGet
    {
        public LicenseActivation NewActivation { get; set; }
        public LicenseCapture NewActivationView { get; set; }

        public List<SelectListItem> UsersOptionAsync { get; set; } // New property
        //public List<SelectListItem> TypeOptionsAsync { get; set; } // New property
        //public List<SelectListItem> SupplierOptionsAsync { get; set; } // New property
        public List<LicenseCapture> LicenseActivationList { get; set; }
        public List<LicenseActivation> ActivationList { get; set; }

        public int CaptureId { get; set; } // Add this property

        public LicenseActivationGet()
        {
            NewActivation = new LicenseActivation();
            UsersOptionAsync = new List<SelectListItem>(); // Initialize the list
            //TypeOptionsAsync = new List<SelectListItem>(); // Initialize the list
            //SupplierOptionsAsync = new List<SelectListItem>(); // Initialize the list
            NewActivationView = new LicenseCapture();
            LicenseActivationList = new List<LicenseCapture>();
            ActivationList = new List<LicenseActivation>();



        }
    }
    public class LicenseViewGet
    {
        public LicenseCapture NewViewLicense { get; set; }
        public int CaptureId { get; set; } // Add this property

        public LicenseViewGet()
        {
            NewViewLicense = new LicenseCapture();
        }
    }
    public class LicenseCaptureForm
    {
      
        public List<SelectListItem> UsersOptionAsync { get; set; } // New property
        public List<SelectListItem> TypeOptionsAsync { get; set; } // New property
        public List<SelectListItem> SupplierOptionsAsync { get; set; } // New property

        public LicenseCapture NewCaptureForm { get; set; }
        public LicenseCaptureForm()
        {
          
            UsersOptionAsync = new List<SelectListItem>(); // Initialize the list
            TypeOptionsAsync = new List<SelectListItem>(); // Initialize the list
            SupplierOptionsAsync = new List<SelectListItem>(); // Initialize the list
            NewCaptureForm = new LicenseCapture();
      

        }
    }


    public class LicenseCaptureGet
    {
        public List<string> LicenseCSuppliesList { get; set; }
        public List<string> LicenseCUsersList { get; set; }
        public List<string> LicenseCTypeList { get; set; }
        public List<SelectListItem> UsersOptionAsync { get; set; } // New property
        public List<SelectListItem> TypeOptionsAsync { get; set; } // New property
        public List<SelectListItem> SupplierOptionsAsync { get; set; } // New property
        public List<LicenseCapture> LicenseCaptureList { get; set; }

        public LicenseCapture NewLicenseCapture { get; set; }
        public LicenseActivation NewLicenseUser { get; set; }
        public LicenseRemainder NewLicenseRemainder { get; set; }


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
            NewLicenseUser = new LicenseActivation();
            NewLicenseRemainder = new LicenseRemainder();
                LicenseCaptureList = new List<LicenseCapture>();
            //CaptureId = 0; // You can set it to an initial value if needed

        }
    }
    public class LicenseEditGet
    {
       
        public List<SelectListItem> UsersOptionAsync { get; set; } // New property
        public List<SelectListItem> TypeOptionsAsync { get; set; } // New property
        public List<SelectListItem> SupplierOptionsAsync { get; set; } // New property

        public LicenseCapture NewEditCapture { get; set; }
        public List<LicenseCapture> LicenseEditList { get; set; }


        public int CaptureId { get; set; } // Add this property


        public LicenseEditGet()
        {
  
            UsersOptionAsync = new List<SelectListItem>(); // Initialize the list
            TypeOptionsAsync = new List<SelectListItem>(); // Initialize the list
            SupplierOptionsAsync = new List<SelectListItem>(); // Initialize the list
            NewEditCapture = new LicenseCapture();
            LicenseEditList = new List<LicenseCapture>();



        }
    }
    public class LicenseRemainder
    {
        [Key]
        public int ReminderId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required, StringLength(100)]
        public string LicenseUser { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime RemainderDate { get; set; }

        [MaxLength]
        public string Comment { get; set; }

        // Navigation property to represent the User
        public Users? User { get; set; }
    }
    public class LicenseRemainderGet
    {

        public List<SelectListItem> UsersOptionAsync { get; set; } // New property
        public LicenseRemainder NewLicenseRemainder { get; set; }

        public int CaptureId { get; set; } // Add this property

        public LicenseRemainderGet()
        {
         
            UsersOptionAsync = new List<SelectListItem>(); // Initialize the list        
            NewLicenseRemainder = new LicenseRemainder();
         
        }
    }
    //public class LicenseActivationGet
    //{




    //    public LicenseRemainder NewLicenseRemainder { get; set; }



    //    public LicenseActivationGet()
    //    {

    //        NewLicenseRemainder = new LicenseRemainder();


    //    }
    //}


}
