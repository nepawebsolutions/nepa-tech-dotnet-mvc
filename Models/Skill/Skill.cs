using System.ComponentModel.DataAnnotations;

namespace NEPATechDotnetCoreMVC.Models.Skill
{
    public class Skill
    {
        [Required]
        [Key]
        public int SkillId { get; set; }


        [Required]
        public int UserId { get; set; }


        [Required]
        [MaxLength(16)]
        public string SkillName { get; set; }
    }
}
