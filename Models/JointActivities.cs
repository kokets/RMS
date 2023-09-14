using System.ComponentModel.DataAnnotations;


//model to handle all the gifts database queries


namespace HSRC_RMS.Models
{

    public class JointActivitiesRegister
    {
        [Key] // This attribute marks GiftId as the primary key
        public int ActivityID { get; set; }


        [Required(ErrorMessage = "Opportunity Title is required")]
        public string? Budgetyears { get; set; }

        [Required(ErrorMessage = "Opportunity Title is required")]
        public int? BudgetYear { get; set; }

        [Required(ErrorMessage = "Opportunity Funder is required")]
        public string? Activity { get; set; }

        [Required(ErrorMessage = "Opportunity Program is required")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Opportunity Program is required")]
        public string? Institution { get; set; }

        [Required(ErrorMessage = "Opportunity Program is required")]
        public string? Descriptions { get; set; }

        [Required(ErrorMessage = "Opportunity Program is required")]
        public string? Collaboration { get; set; }

        [Required(ErrorMessage = "Opportunity Status is required")]
        public string? Status { get; set; }

        [Required(ErrorMessage = "Opportunity Url is required")]
        public DateTime? Dates { get; set; }


        [Required(ErrorMessage = "Opportunity SubmissionDate is required")]
        public string? Document { get; set; }

    }


    public class JointActivitiesDisplay
    {
        [Key] // This attribute marks GiftId as the primary key
        public int ActivityID { get; set; }

        public int? BudgetYear { get; set; }


        [Required(ErrorMessage = "Opportunity Title is required")]
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

}
