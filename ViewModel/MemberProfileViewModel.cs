using NEPATechDotnetCoreMVC.Models.MemberProfile;
using NEPATechDotnetCoreMVC.Models.MockUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEPATechDotnetCoreMVC.ViewModel
{
    public class MemberProfileViewModel
    {
            public User Member { get; set; }
            public MemberProfile Profile { get; set; }
            
    }
}
