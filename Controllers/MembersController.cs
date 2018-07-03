using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NEPATechDotnetCoreMVC.Data;
using NEPATechDotnetCoreMVC.Models;
using NEPATechDotnetCoreMVC.ViewModel;

namespace NEPATechDotnetCoreMVC.Controllers
{
    public class MembersController : Controller
    {
        private readonly NEPATechDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MembersController(NEPATechDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index(int? page)
        {

            //Accesses the pager class which handles pagination
            var members = _context.Users;
            var pager = new Pager(members.Count(), page);


            var profileModel = new MemberProfilesViewModel
            {
                Profile = members
            };

            var viewModel = new MembersViewModel
            {

                Members = profileModel,
                Pager = pager
            };
            return View(viewModel);
        }

        //public async Task<IActionResult> Details(int id)
        //{

        //    //Creating a random collection of names
        //    var selectedUser = await _userManager.FindByIdAsync(id.ToString());
        //    var userProfile = _context.MemberProfiles.Where(mu => mu.UserId.ToString().Equals(selectedUser.Id));
        //    var userSkills = _context.Skills.Where(mu => mu.UserId.ToString().Equals(selectedUser.Id));
        //    var userProjects = _context.Projects.Where(mu => mu.UserId.ToString().Equals(selectedUser.Id));

        //    //var MembersProfiles = dummyMembers.Join(dummyProfiles, keyId => keyId.MemberProfileId, mKeyId => mKeyId.MemberProfileId,
        //    //    (member, profile) => new MemberProfileViewModel
        //    //    {
        //    //        Member = member,
        //    //        Profile = profile
        //    //    });

        //    var viewModel = new MembersViewModel
        //    {

        //        Member = selectedUser,
        //        Skills = userSkills
        //    };
        //    return View(viewModel);
        //}
    }
}