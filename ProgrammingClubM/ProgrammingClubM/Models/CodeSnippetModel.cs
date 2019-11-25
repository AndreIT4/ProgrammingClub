using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProgrammingClubM.Models
{
    public class CodeSnippetModel
    {
        public Guid IDCodeSnippet { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max. 250 chars")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max. 250 chars")]
        public string ContentCode { get; set; }

        public Guid IDMember { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max. 250 chars")]
        public int Revision { get; set; }

        public Guid? IDSnippetPreviousVersion { get; set; }
        public DateTime DateTimeAdded { get; set; }

        public bool IsPublished { get; set; }
    }
}