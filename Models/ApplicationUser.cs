using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace NEPATechDotnetCoreMVC.Models
{
    public class ApplicationUser : IdentityUser 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Biography { get; set; }
        public DateTime LastActive { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Project.Project> Projects { get; set; }
        public ICollection<Skill.Skill> Skills { get; set; }
    }
}
