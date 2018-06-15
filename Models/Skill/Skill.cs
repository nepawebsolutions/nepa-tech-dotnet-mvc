using NEPATechDotnetCoreMVC.Models.MockUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NEPATechDotnetCoreMVC.Models.Skill
{
    public class Skill
    {
        [Required]
        public int SkillId { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        [MaxLength(16)]
        public string SkillName { get; set; }
    }
}
