using System.ComponentModel.DataAnnotations;


//model to handle all the gifts database queries


namespace HSRC_RMS.Models
{

    public class JointAcademicRegister
    {
        [Key] // This attribute marks GiftId as the primary key
        public int AcademicId { get; set; }



        [Required(ErrorMessage = "Opportunity Title is required")]
        public int? BudgetYear { get; set; }

        [Required(ErrorMessage = "Opportunity Title is required")]
        public string? Budgetyears { get; set; }

        [Required(ErrorMessage = "Opportunity Funder is required")]
        public string? Staff { get; set; }

        [Required(ErrorMessage = "Opportunity Program is required")]
        public string? Position { get; set; }

		[Required(ErrorMessage = "Opportunity Program is required")]
		public string? Institution { get; set; }

		[Required(ErrorMessage = "Opportunity Program is required")]
		public string? Descriptions { get; set; }

		[Required(ErrorMessage = "Opportunity Status is required")]
        public String? Status { get; set; }

        [Required(ErrorMessage = "Opportunity Url is required")]
        public DateTime? StartDate { get; set; }

		[Required(ErrorMessage = "Opportunity Url is required")]
		public DateTime? EndDate { get; set; }

		[Required(ErrorMessage = "Opportunity SubmissionDate is required")]
        public string? Document { get; set; }

    }


    public class JointAcademicDisplay
    {
        [Key] // This attribute marks GiftId as the primary key
        public int AcademicId { get; set; }

		public int? BudgetYear { get; set; }

        public string? Budgetyears { get; set; }


        [Required(ErrorMessage = "Opportunity Title is required")]
        public string? Staff { get; set; }

        public string? Position { get; set; }

        public string? Institution { get; set; }

		public string? Descriptions { get; set; }

		public DateTime? StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		public String? Status { get; set; }

        public string? Document { get; set; }


    }

}
