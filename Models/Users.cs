using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HSRC_RMS.Models
{

    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [MaxLength(256)]
        public string Password { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(20)]
        public string? RoleName { get; set; }
    }

}
