using NEPATechDotnetCoreMVC.Models.MockUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NEPATechDotnetCoreMVC.Models.Project
{
    public class Project
    {
        [Required]
        public int ProjectId { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        [MaxLength(32)]
        public string ProjectName { get; set; }
        [Required]
        public string ProjectDesc { get; set; }
        [Required]
        public string ProjectLink { get; set; }
    }
}
