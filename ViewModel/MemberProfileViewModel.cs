using NEPATechDotnetCoreMVC.Models;
using System.Collections.Generic;

namespace NEPATechDotnetCoreMVC.ViewModel
{
    public class MemberProfilesViewModel
    {
        public IEnumerable<ApplicationUser> Profile { get; set; }
            
    }
}
