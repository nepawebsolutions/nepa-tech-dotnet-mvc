using Microsoft.EntityFrameworkCore;
using NEPATechDotnetCoreMVC.Models.ContactLog;
using NEPATechDotnetCoreMVC.Models.MemberProfile;
using NEPATechDotnetCoreMVC.Models.Skill;
using NEPATechDotnetCoreMVC.Models.Project;
using NEPATechDotnetCoreMVC.Models.MockUsers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NEPATechDotnetCoreMVC.Models;

namespace NEPATechDotnetCoreMVC.Data
{
    public class NEPATechDbContext : IdentityDbContext<ApplicationUser>
    {
        public NEPATechDbContext(DbContextOptions<NEPATechDbContext> options) 
            : base(options)
        { }

        public DbSet<ContactLog> ContactLogs { get; set; }
        public DbSet<MemberProfile> MemberProfiles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<User> MockUsers { get; set; }
    }
}
