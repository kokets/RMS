using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


//model to handle all the gifts database queries


namespace HSRC_RMS.Models
{

    public class JointActivitiesRegister
    {
        [Key] // This attribute marks GiftId as the primary key
        public int ActivityID { get; set; }


      
        public string? Budgetyears { get; set; }

      
        public string? Activity { get; set; }

       
        public string? Title { get; set; }

       
        public string? Institution { get; set; }

       
        public string? Descriptions { get; set; }

      
        public string? Collaboration { get; set; }

      
        public string? Status { get; set; }

      
        public DateTime? Dates { get; set; }


        [Required(ErrorMessage = "Opportunity SubmissionDate is required")]
        public string? Document { get; set; }

    }


    public class JointActivitiesDisplay
    {
        [Key] // This attribute marks GiftId as the primary key
        public int ActivityID { get; set; }


      
        public string? Activity { get; set; }

        public string? Budgetyears { get; set; }
        public string? Title { get; set; }

        public string? Institution { get; set; }

        public string? Descriptions { get; set; }

        public string? Collaboration { get; set; }

        public DateTime? Dates { get; set; }

        public string? Status { get; set; }

        public string? Document { get; set; }


    }

    public class JointActivitiesEditGet
    {

        public List<SelectListItem> UsersOptionAsync { get; set; } // New property
        public List<SelectListItem> TypeOptionsAsync { get; set; } // New property
        public List<SelectListItem> SupplierOptionsAsync { get; set; } // New property

        public JointActivitiesRegister NewEditCapture { get; set; }
        public List<JointActivitiesRegister> LicenseEditList { get; set; }


        public int ActivityID { get; set; } // Add this property


        public JointActivitiesEditGet()
        {

            UsersOptionAsync = new List<SelectListItem>(); // Initialize the list
            TypeOptionsAsync = new List<SelectListItem>(); // Initialize the list
            SupplierOptionsAsync = new List<SelectListItem>(); // Initialize the list
            NewEditCapture = new JointActivitiesRegister();
            LicenseEditList = new List<JointActivitiesRegister>();



        }
    }

}
