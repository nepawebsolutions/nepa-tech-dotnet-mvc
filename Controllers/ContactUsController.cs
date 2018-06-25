using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NEPATechDotnetCoreMVC.Data;
using NEPATechDotnetCoreMVC.ViewModel;

namespace NEPATechDotnetCoreMVC.Controllers
{
    public class ContactUsController : Controller
    {
        [BindProperty]
        public string fname { get; set; }
        [BindProperty]
        public string lname { get; set; }
        [BindProperty]
        public string email { get; set; }
        [BindProperty]
        public string complaint { get; set; }

        private ContactViewModel contactViewModel = new ContactViewModel();
        private NEPATechDbContext _context;

        public ContactUsController(NEPATechDbContext _context)
        {
            contactViewModel.isComplaintSent = false;
            this._context = _context;
        }

        public IActionResult Index()
        {
            if(Request.Method == "POST")
            {
                var ContactLogs = _context.ContactLogs;
                ContactLogs.Add(new Models.ContactLog.ContactLog
                {
                    FName = fname,
                    LName = lname,
                    Email = email,
                    Message = complaint
                });

                _context.SaveChanges();
                contactViewModel.isComplaintSent = true;
            }
            return View(contactViewModel);
        }
        public IActionResult eventsRedirect()
        {
            return Redirect("https://www.meetup.com/NEPATech/events/past/");
        }
    }
}