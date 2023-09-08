using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace HSRC_RMS.Models
{
    public class Files
    {
        [Key]
        public string DocumentId { get; set; }
        [MaxLength(100)]

        public string Name { get; set; }
        [MaxLength(100)]

        public string FileType { get; set; }
        [MaxLength]

        public byte[] FirstContent { get; set; }
        [MaxLength]

        public byte[] SecondContent { get; set; }
    }
    public class MouCreate
    {
        [Key]
        public int CreateId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required, StringLength(100)]

        public string Division { get; set; }
        [Required, StringLength(100)]

        public string Requester { get; set; }

        public int ContactDetails { get; set; }
        [ StringLength(100)]

        public string MouRequest { get; set; }
        [ StringLength(100)]

        public string AgreementType { get; set; }
        [ StringLength(100)]

        public string PartnerName { get; set; }
        [ StringLength(100)]

        public string InstitutionType { get; set; }
        [StringLength(256)]

        public string MouPurpose { get; set; }
        [ForeignKey("UserId")]
        public Users? User { get; set; } // Assuming you have a Users model

        public DateTime DateCapture { get; set; }
        [StringLength(100)]

        public string ReferenceNumber { get; set; }
    }

    public class MouCreateDelete
    {
        public MouCreate MouViewDelete { get; set; }
        public int MouCreateId { get; set; } // Add this property

        public MouCreateDelete()
        {
            MouViewDelete = new MouCreate();
        }
    }
}
