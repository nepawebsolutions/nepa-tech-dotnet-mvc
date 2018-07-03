using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NEPATechDotnetCoreMVC.Data;
using NEPATechDotnetCoreMVC.Models;
using NEPATechDotnetCoreMVC.ViewModel;

namespace NEPATechDotnetCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private NEPATechDbContext _context;
        private HomeViewModel membersOnWebsite = null;
       
        public HomeController(NEPATechDbContext _context)
        {
            this._context = _context;

        }

        public IActionResult Index()
        {
            var a = User;
            membersOnWebsite = new HomeViewModel
            {
                MembersOnWebsite = _context.Users.Count()
            };
            ViewData["Title"] = "Welcome ";
            return View(membersOnWebsite);
        }
        

        public IActionResult ContactUs()
        {
            ViewData["Message"] = "Your contact page.";

            return RedirectToAction("Index","ContactUs");
        }

        public IActionResult Members()
        {
            ViewData["Message"] = "Your Members Page.";

            return RedirectToAction("Index", "Members");
        }

        public IActionResult Events()
        {
            ViewData["Message"] = "Your Events Page.";

            return View();
        }
        public IActionResult Elements()
        {
            ViewData["Message"] = "Your Events Page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
