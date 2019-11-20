using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgrammingClubM.Models
{
    public class AnnouncementModel
    {
        public Guid IDAnnouncement { get; set; }

        [Required(ErrorMessage="Mandatory field")]
        public DateTime ValidFrom { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public DateTime ValidTo { get; set; }

        [Required(ErrorMessage= "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max.250 chars")]

     
        public string Title { get; set; }
        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(1000, ErrorMessage = "String too long (max. 1000 chars")]

        public string Text { get; set; }

        public DateTime? EventDateTime { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(1000, ErrorMessage = "String too long(max. 1000 chars")]

        public string Tags { get; set; }
    }
}