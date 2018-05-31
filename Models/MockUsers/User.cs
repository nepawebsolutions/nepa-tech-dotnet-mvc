using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NEPATechDotnetCoreMVC.Models.MockUsers
{
    public class User
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        [MaxLength(32)]
        public string FName { get; set; }
        [Required]
        [MaxLength(32)]
        public string LName { get; set; }
        [Required]
        [ForeignKey("MemberProfile")]
        public int MemberProfileId { get; set; }
    }
}
