using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NEPATechDotnetCoreMVC.Models.ContactLog
{
    public class ContactLog
    {
        [Required]
        public int ContactLogId { get; set; }
        [Required]
        [MaxLength(32)]
        public string FName { get; set; }
        [Required]
        [MaxLength(32)]
        public string LName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
