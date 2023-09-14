using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace HSRC_RMS.Models
{
    public class Files
    {
        [Key]
        public int DocumentId { get; set; }
        [MaxLength(100)]

        public string FirstName { get; set; }
		[MaxLength(100)]

		public string SecondName { get; set; }
		[MaxLength(100)]

        public string FirstFileType { get; set; }
        [MaxLength(100)]

        public string SecondFileType { get; set; }
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

        [MaxLength(100)]

        public string? FirstName { get; set; }
        [MaxLength(100)]

        public string? SecondName { get; set; }
        [MaxLength(100)]

        public string? FirstFileType { get; set; }
        [MaxLength(100)]

        public string? SecondFileType { get; set; }
        [MaxLength]

        public byte[]? FirstContent { get; set; }
        [MaxLength]

        public byte[]? SecondContent { get; set; }
    }
    public class MouCreateEdit
    {
        public MouCreate MouViewEdit { get; set; }
        public int MouCreateId { get; set; } // Add this property

        public MouCreateEdit()
        {
            MouViewEdit = new MouCreate();
        }
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
    public class MoUView
    {
        public MouCreate MouView { get; set; }
        public int MouCreateId { get; set; } // Add this property

        public MoUView()
        {
            MouView = new MouCreate();
        }
    }
    public class MoUViewRequest
    {
        public MouCreate MouViewRequestById { get; set; }
        public int MouCreateId { get; set; } // Add this property

        public MoUViewRequest()
        {
            MouViewRequestById = new MouCreate();
        }
    }
}
