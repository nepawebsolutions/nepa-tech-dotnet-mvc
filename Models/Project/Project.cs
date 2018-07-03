using System.ComponentModel.DataAnnotations;

namespace NEPATechDotnetCoreMVC.Models.Project
{
    public class Project
    {
        [Required]
        [Key]
        public int ProjectId { get; set; }


        [Required]
        [MaxLength(32)]
        public string ProjectName { get; set; }
        [Required]
        public string ProjectDesc { get; set; }
        [Required]
        public string ProjectLink { get; set; }
    }
}
