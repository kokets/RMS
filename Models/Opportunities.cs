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
        public bool Status { get; set; }

        [Required(ErrorMessage = "Opportunity Url is required")]
        public string? Url { get; set; }

        [Required(ErrorMessage = "Opportunity SubmissionDate is required")]
        public string? SubmissionDate { get; set; }

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

        public bool Status { get; set; }
        public string? Url { get; set; }
        public string? SubmissionDate { get; set; }


    }

}
