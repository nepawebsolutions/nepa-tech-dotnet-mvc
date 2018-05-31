using Microsoft.EntityFrameworkCore;
using NEPATechDotnetCoreMVC.Models.ContactLog;
using NEPATechDotnetCoreMVC.Models.MemberProfile;
using NEPATechDotnetCoreMVC.Models.Skill;
using NEPATechDotnetCoreMVC.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEPATechDotnetCoreMVC.Data
{
    public class NEPATechDbContext : DbContext
    {
        public NEPATechDbContext(DbContextOptions<NEPATechDbContext> options) 
            : base(options)
        { }

        public DbSet<ContactLog> ContactLogs { get; set; }
        public DbSet<MemberProfile> MemberProfiles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
