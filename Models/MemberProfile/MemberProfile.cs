using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NEPATechDotnetCoreMVC.Models.MemberProfile
{
    public class MemberProfile
    {
        [Required]
        public int MemberProfileId { get; set; }
        [Required]
        public int UserId { get; set; }
        public string Biography { get; set; }
        public DateTime LastActive { get; set; }
    }
}
