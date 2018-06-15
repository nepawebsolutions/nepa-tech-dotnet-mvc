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
            //Creating a random collection of names
            var dummyMembers = _context.MockUsers.ToList();
            var dummyProfiles = _context.MemberProfiles.ToList();
            var MembersProfiles = dummyMembers.Join(dummyProfiles, keyId => keyId.MemberProfileId, mKeyId => mKeyId.MemberProfileId, 
                (member, profile) => new MemberProfileViewModel {
                    Member = member,
                    Profile = profile
                }).ToList();

            //Accesses the pager class which handles pagination
            var pager = new Pager(dummyMembers.Count(), page);
            Random random = new Random();

            
            var viewModel = new MembersViewModel {

                Members = MembersProfiles.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {

            //Creating a random collection of names
            var dummyMembers = _context.MockUsers.ToList();
            var dummyProfiles = _context.MemberProfiles.ToList();
            var dummySkills = _context.Skills.ToList();
            var dummyProjects = _context.Projects.ToList();

            var MembersProfiles = dummyMembers.Join(dummyProfiles, keyId => keyId.MemberProfileId, mKeyId => mKeyId.MemberProfileId,
                (member, profile) => new MemberProfileViewModel
                {
                    Member = member,
                    Profile = profile
                }).ToList();

            var viewModel = new MembersViewModel
            {

                Members = MembersProfiles.Where(dt => dt.Member.UserId == id),
                Skills = dummySkills.Where(s => s.UserId == id)
            };
            return View(viewModel);
        }
    }
}