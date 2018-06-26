using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NEPATechDotnetCoreMVC.Models
{
    public class ApplicationUser : IdentityUser 
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ForeignKey("MemberProfile")]
        public int MemberProfileId { get; set; }
    }
}
