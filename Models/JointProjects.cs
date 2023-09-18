using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


//model to handle all the gifts database queries


namespace HSRC_RMS.Models
{

    public class JointProjectsRegister
    {
        [Key] // This attribute marks GiftId as the primary key
        public int ProjectID { get; set; }

        public string? Budgetyears { get; set; }


        [Required(ErrorMessage = "Opportunity Funder is required")]
        public string? ProjectNumber { get; set; }

        [Required(ErrorMessage = "Opportunity Program is required")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Opportunity Program is required")]
        public string? Institution { get; set; }


        [Required(ErrorMessage = "Opportunity Status is required")]
        public String? Status { get; set; }

        [Required(ErrorMessage = "Opportunity Url is required")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Opportunity Url is required")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Opportunity SubmissionDate is required")]
        public string? Document { get; set; }

    }


    public class JointProjectsDisplay
    {
        [Key] // This attribute marks GiftId as the primary key
        public int ProjectID { get; set; }



       
        public string? Budgetyears { get; set; }

        [Required(ErrorMessage = "Opportunity Title is required")]
        public string? ProjectNumber { get; set; }

        public string? Title { get; set; }

        public string? Institution { get; set; }


        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public String? Status { get; set; }

        public string? Document { get; set; }


    }

    public class JointProjectsEditGet
    {

        public List<SelectListItem> UsersOptionAsync { get; set; } // New property
        public List<SelectListItem> TypeOptionsAsync { get; set; } // New property
        public List<SelectListItem> SupplierOptionsAsync { get; set; } // New property

        public JointProjectsRegister NewEditCapture { get; set; }
        public List<JointProjectsRegister> LicenseEditList { get; set; }


        public int ProjectID { get; set; } // Add this property


        public JointProjectsEditGet()
        {

            UsersOptionAsync = new List<SelectListItem>(); // Initialize the list
            TypeOptionsAsync = new List<SelectListItem>(); // Initialize the list
            SupplierOptionsAsync = new List<SelectListItem>(); // Initialize the list
            NewEditCapture = new JointProjectsRegister();
            LicenseEditList = new List<JointProjectsRegister>();



        }
    }

}
