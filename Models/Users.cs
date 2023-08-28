using System.ComponentModel.DataAnnotations;

namespace HSRC_RMS.Models
{
    public class Users
    {
        [Key] // This attribute marks GiftId as the primary key
        public int UserId { get; set; }

        [Required]
#pragma warning disable CS8618 // Non-nullable property 'Username' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Username { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Username' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

        [Required]
        [DataType(DataType.Password)]
#pragma warning disable CS8618 // Non-nullable property 'Password' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Password { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Password' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

        [Required]
        [EmailAddress]
#pragma warning disable CS8618 // Non-nullable property 'Email' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Email { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Email' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}
