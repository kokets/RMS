using System.ComponentModel.DataAnnotations;

namespace HSRC_RMS.Models
{
    public class Event
    {
        [Key] // This attribute marks EventId as the primary key
        public int EventId { get; set; }

        public int UserId { get; set; }
        [Required, StringLength(250)]
        public string EventType { get; set; }

        [Required, StringLength(200)]
        public string Unit { get; set; }
        [Required, StringLength(150)]
        public string Title { get; set; }
        public DateTime SubmissionDate { get; set; }

        [ StringLength(50)]

        public string? EventStatus { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        [Required, StringLength(150)]
        public string Institution { get; set; }
        public string EventComments { get; set; }


    
        [StringLength(150)]
        public string? FirstFileType { get; set; }
        public byte[]? FirstContent { get; set; }


 
        [StringLength(150)]
        public string? SecondFileType { get; set; }
        public byte[]? SecondContent { get; set; }



        [StringLength(150)]
        public string? ThirdFileType { get; set; }
        public byte[]? ThirdContent { get; set; }


        [StringLength(150)]
        public string? FourthFileType { get; set; }
        public byte[]? FourthContent { get; set; }


        [StringLength(150)]
        public string? FifthFileType { get; set; }
        public byte[]? FifthContent { get; set; }
    }

    public class EventFiles
    {
        [Key]
        public int DocumentId { get; set; }

        public int EventId { get; set; }


        [StringLength(100)]
        public string? FirstName { get; set; }
        [StringLength(150)]
        public string? FirstFileType { get; set; }
        public byte[]? FirstContent { get; set; }


        [StringLength(100)]
        public string? SecondName { get; set; }
        [StringLength(150)]
        public string? SecondFileType { get; set; }
        public byte[]? SecondContent { get; set; }


        [StringLength(100)]
        public string? ThirdName { get; set; }
        [StringLength(150)]
        public string? ThirdFileType { get; set; }
        public byte[]? ThirdContent { get; set; }


        [StringLength(100)]
        public string? FourthName { get; set; }
        [StringLength(150)]
        public string? FourthFileType { get; set; }
        public byte[]? FourthContent { get; set; }


        [StringLength(100)]
        public string? FifthName { get; set; }
        [StringLength(150)]
        public string? FifthFileType { get; set; }
        public byte[]? FifthContent { get; set; }
    }

    public class EventCapture
    {
        public Event NewEvent { get; set; }
        public EventFiles NewEventFile { get; set; }
        public List<EventFiles> EventFilesList { get; set; }
        public List<Event> EventList { get; set; }

        public EventCapture()
        {
            NewEvent = new Event();
            NewEventFile = new EventFiles();
            EventList = new List<Event>();
            EventFilesList = new List<EventFiles>();
        }
    }
}
