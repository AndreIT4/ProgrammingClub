using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProgrammingClubM.Models
{
    public class MembershipModel
    {
        public Guid IDMembership { get; set; }

        public Guid IDMember { get; set; }

        public Guid IDMembershipType { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
       
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
       
        public int Level { get; set; }
    }
}