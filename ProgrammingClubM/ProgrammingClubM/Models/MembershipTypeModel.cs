using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProgrammingClubM.Models
{
    public class MembershipTypeModel
    {
        public Guid IDMembershipType { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max. 250 chars")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(1000, ErrorMessage = "String too long (max. 1000 chars")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        
        public int SubscriptionLengthInMonths { get; set; }
    }
}