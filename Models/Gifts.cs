using System.ComponentModel.DataAnnotations;


//model to handle all the gifts database queries


namespace HSRC_RMS.Models
{

    public class GiftRegister
    {
        [Key] // This attribute marks GiftId as the primary key
        public int GiftId { get; set; }

        public int UserId { get; set; } // foreign key
        public Users? User { get; set; } // Assuming you have a User model

        [Required(ErrorMessage = "Gift Sponsor is required")]
        public string GiftSponsor { get; set; }

        public string? GiftOrganization { get; set; }

        [Required(ErrorMessage = "Nature of the Business is required")]
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string NatureOfBusiness { get; set; }
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public string? GiftDescription { get; set; }

        [Required(ErrorMessage = "Value is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Value must be greater than 0")]
        public decimal Value { get; set; }

        public string? PurposeOfGift { get; set; }

        [Required(ErrorMessage = "Please select whether the gift was received in appreciation of work done")]
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string ReceivedInAppreciation { get; set; }
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }


    public class GiftDisplay
    {
        [Key] // This attribute marks GiftId as the primary key
        public int GiftId { get; set; }

        public int UserId { get; set; } // foreign key
        public string UserName { get; set; } // New property for username

        //public Users User { get; set; } // Assuming you have a User model

        [Required(ErrorMessage = "Gift Sponsor is required")]
        public string GiftSponsor { get; set; }

        public string? GiftOrganization { get; set; }

        [Required(ErrorMessage = "Nature of the Business is required")]
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string NatureOfBusiness { get; set; }
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public string? GiftDescription { get; set; }

        [Required(ErrorMessage = "Value is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Value must be greater than 0")]
        public decimal Value { get; set; }

        public string? PurposeOfGift { get; set; }

        [Required(ErrorMessage = "Please select whether the gift was received in appreciation of work done")]
         #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string ReceivedInAppreciation { get; set; }
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        // Computed property for current date
        public DateTime CurrentDate { get; set; } // Property for current date

        public string Comment { get; set; }

    }


    public class GiftComment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public int GiftId { get; set; }

        [Required]
        [StringLength(50)]
        public string Comment { get; set; }

     
    }

}
