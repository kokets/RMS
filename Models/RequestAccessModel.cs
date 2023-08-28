using System.ComponentModel.DataAnnotations;

namespace HSRC_RMS.Models
{
    public class RequestAccessModel
    {
        [Required]
#pragma warning disable CS8618 // Non-nullable property 'FunctionName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string FunctionName { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'FunctionName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

#pragma warning disable CS8618 // Non-nullable property 'Description' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Description { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Description' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}
