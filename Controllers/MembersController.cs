using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NEPATechDotnetCoreMVC.Data;
using NEPATechDotnetCoreMVC.ViewModel;

namespace NEPATechDotnetCoreMVC.Controllers
{
    public class MembersController : Controller
    {
        private readonly NEPATechDbContext _context;

        public MembersController(NEPATechDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(int? page)
        {

            //Accesses the pager class which handles pagination
            var dummyMembers = _context.MockUsers;
            var pager = new Pager(dummyMembers.Count(), page);

            //Creating a random collection of names
            var dummyProfiles = _context.MemberProfiles.Skip((pager.PreviousPage) * pager.PageSize).Take(pager.PageSize);
            var MembersProfiles = dummyMembers.Join(dummyProfiles, keyId => keyId.MemberProfileId, mKeyId => mKeyId.MemberProfileId, 
                (member, profile) => new MemberProfileViewModel {
                    Member = member,
                    Profile = profile
                });

            
            var viewModel = new MembersViewModel {

                Members = MembersProfiles,
                Pager = pager
            };
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {

            //Creating a random collection of names
            var dummyMembers = _context.MockUsers.Where(mu=> mu.UserId == id);
            var dummyProfiles = _context.MemberProfiles.Where(mu => mu.UserId == id);
            var dummySkills = _context.Skills.Where(mu => mu.UserId == id);
            var dummyProjects = _context.Projects.Where(mu => mu.UserId == id);

            var MembersProfiles = dummyMembers.Join(dummyProfiles, keyId => keyId.MemberProfileId, mKeyId => mKeyId.MemberProfileId,
                (member, profile) => new MemberProfileViewModel
                {
                    Member = member,
                    Profile = profile
                });

            var viewModel = new MembersViewModel
            {

                Members = MembersProfiles.Where(dt => dt.Member.UserId == id),
                Skills = dummySkills.Where(s => s.UserId == id)
            };
            return View(viewModel);
        }
    }
}