using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


//model to handle all the gifts database queries


namespace HSRC_RMS.Models
{

    public class OpportunitiesRegister
    {
        [Key] // This attribute marks GiftId as the primary key
        public int opportunityId { get; set; }

        public int UserId { get; set; } // foreign key

        [Required(ErrorMessage = "Opportunity Title is required")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Opportunity Funder is required")]
        public string? Funder { get; set; }

        [Required(ErrorMessage = "Opportunity Program is required")]
        public string? Program { get; set; }

        [Required(ErrorMessage = "Opportunity Status is required")]
        public string? Status { get; set; }

        [Required(ErrorMessage = "Opportunity Url is required")]
        public string? Url { get; set; }

        [Required(ErrorMessage = "Opportunity SubmissionDate is required")]
        public DateTime? SubmissionDate { get; set; }

    }


    public class OpportunitiesDisplay
    {
        [Key] // This attribute marks GiftId as the primary key
        public int opportunityId { get; set; }

        public int UserId { get; set; } // foreign key


        [Required(ErrorMessage = "Opportunity Title is required")]
        public string? Title { get; set; }

        public string? Funder { get; set; }

        public string? Program { get; set; }

        public string Status { get; set; }
        public string? Url { get; set; }
        public DateTime? SubmissionDate { get; set; }


    }

    public class OpportunitiesEditGet
    {

        public List<SelectListItem> UsersOptionAsync { get; set; } // New property
        public List<SelectListItem> TypeOptionsAsync { get; set; } // New property
        public List<SelectListItem> SupplierOptionsAsync { get; set; } // New property

        public OpportunitiesRegister NewEditCapture { get; set; }
        public List<OpportunitiesRegister> LicenseEditList { get; set; }


        public int opportunityId { get; set; } // Add this property


        public OpportunitiesEditGet()
        {

            UsersOptionAsync = new List<SelectListItem>(); // Initialize the list
            TypeOptionsAsync = new List<SelectListItem>(); // Initialize the list
            SupplierOptionsAsync = new List<SelectListItem>(); // Initialize the list
            NewEditCapture = new OpportunitiesRegister();
            LicenseEditList = new List<OpportunitiesRegister>();



        }
    }


	public class OpportunitiesViewGet
	{
		public OpportunitiesRegister NewViewLicense { get; set; }
		public int opportunityId { get; set; } // Add this property

		public OpportunitiesViewGet()
		{
			NewViewLicense = new OpportunitiesRegister();
		}
	}

}
