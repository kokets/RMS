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
        public static List<SelectListItem> GetEventTypeOptions()
        {
            return new List<SelectListItem>
            {


                 new SelectListItem { Value = "Community innovations supported or enabled by HSRC research", Text = "Community innovations supported or enabled by HSRC research" },
                new SelectListItem { Value = "Conferences or training academics for young african scholars", Text = "Conferences or training academics for young african scholars" },
                new SelectListItem { Value = "Hospitality-Luncheon invitation by service provider", Text = "Hospitality-Luncheon invitation by service provider" },
                new SelectListItem { Value = "Event dealing with the eradication of poverty, reduction of inequalities and / or promotion of employment convened by the HSRC ", Text = "Event dealing with the eradication of poverty, reduction of inequalities and / or promotion of employment convened by the HSRC " },
                new SelectListItem { Value = "Research related engagements with communities and civil society forums", Text = "Research related engagements with communities and civil society forums" },
                new SelectListItem { Value = "Conferences or training academics for young african scholars ", Text = "Conferences or training academics for young african scholars " },
       
            };
        }

        public static List<SelectListItem> GetDivisionOptions()
        {
            return new List<SelectListItem>
            {
                 new SelectListItem { Value = "[Q] African Institute of South Africa [AISA]", Text = "[Q] African Institute of South Africa [AISA]" },
                new SelectListItem { Value = "[K] Centwer for Science, and Innovation Indicators [CesTII]", Text = "[K] Centwer for Science, and Innovation Indicators [CesTII]" },
                new SelectListItem { Value = "[G] Deputy CEO : Research [DCEO: R]", Text = "[G] Deputy CEO : Research [DCEO: R]" },
                new SelectListItem { Value = "[T] Developmental : Capable and Ethical State [DCES]", Text = "[T] Developmental : Capable and Ethical State [DCES]" },
                new SelectListItem { Value = "[C]Finance [FIN]", Text = "[C]Finance [FIN]" },
                new SelectListItem { Value = "[D] GE Support Service [GE:SS]", Text = "[D] GE Support Service [GE:SS]" },
                new SelectListItem { Value = "[P] Human and Social Capabilities [HSC]", Text = "[P] Human and Social Capabilities [HSC]" },
                new SelectListItem { Value = "[Z] Impact Center [IC]", Text = "[Z] Impact Center [IC]" },
                new SelectListItem { Value = "[L] Inclusive Economic Development [IED]" , Text ="[L] Inclusive Economic Development [IED]" },
                new SelectListItem { Value = "[A] Office of the CEO [OCEO]", Text = "[A] Office of the CEO [OCEO]" }
            };
        }
        public static List<SelectListItem> GetAgreementTypeptions()
        {
            return new List<SelectListItem>
            {
                 new SelectListItem { Value = "Addendum for proposed activities under existing  MOU", Text = "Addendum for proposed activities under existing  MOU" },
                new SelectListItem { Value = "Letter of intent for collaboration", Text = "Letter of intent for collaboration" },
                new SelectListItem { Value = "MoU Renewal", Text = "MoU Renewal" },
                new SelectListItem { Value = "National/Regional/International", Text = "National/Regional/International" },
            
            };
        }

        public static List<SelectListItem> GetInstitutionTypeptions()
        {
            return new List<SelectListItem>
            {
                 new SelectListItem { Value = "Civil Society", Text = "Civil Society" },
                new SelectListItem { Value = "Foundations", Text = "Foundations" },
                new SelectListItem { Value = "Government Department", Text = "Government Department" },
                new SelectListItem { Value = "Non-Profit Company", Text = "Non-Profit Company" },
                                new SelectListItem { Value = "Non-Profit Organization", Text = "Non-Profit Organization" },
                new SelectListItem { Value = "Private Enterprice", Text = "Private Enterprice" },
                new SelectListItem { Value = "Regional Bodies", Text = "Regional Bodies" },
                new SelectListItem { Value = "Science Council", Text = "Science Council" },
                new SelectListItem { Value = "University", Text = "University" },

            };
        }
    }

 
}
