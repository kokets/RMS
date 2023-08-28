using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace HSRC_RMS.Helpers
{
    public class DropdownHelpers
    {
        public static List<SelectListItem> GetNatureOfBusinessOptions()
        {
            return new List<SelectListItem>
            {
                 new SelectListItem { Value = "Collaboration/Partnership", Text = "Collaboration/Partnership" },
                new SelectListItem { Value = "Donation", Text = "Donation" },
                new SelectListItem { Value = "Hospitality-Luncheon invitation by service provider", Text = "Hospitality-Luncheon invitation by service provider" },
                new SelectListItem { Value = "Research award", Text = "Research award" },
                new SelectListItem { Value = "Research symposium participant", Text = "Research symposium participant" },
                new SelectListItem { Value = "Service Provider Contract Appreciation", Text = "Service Provider Contract Appreciation" },
                new SelectListItem { Value = "Speaker at a conference", Text = "Speaker at a conference" },
                new SelectListItem { Value = "Sponsorship", Text = "Sponsorship" },
                new SelectListItem { Value = "Workshop attendees", Text = "Workshop attendees" },
                new SelectListItem { Value = "Other", Text = "Other" }
            };
        }
        public static List<SelectListItem> GetYesNoOption()
        {
            return new List<SelectListItem> { new SelectListItem { Value = "Yes", Text = "Yes" }, new SelectListItem { Value = "No", Text = " No" } };
        }
        public static List<SelectListItem> GetLicenseStatus()

        {
            return new List<SelectListItem> { new SelectListItem { Value = " Active", Text = "Active" }, new SelectListItem { Value = " InActive", Text = "InActive" }, new SelectListItem { Value = " Expired", Text = "Expired" } };
        }
        public static List<SelectListItem> GetStatusOption()
        {
            return new List<SelectListItem> { new SelectListItem { Value = " Active", Text = "Active" }, new SelectListItem { Value = " InActive", Text = "InActive" } };
        }
    }

 
}
