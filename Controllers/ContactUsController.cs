using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NEPATechDotnetCoreMVC.ViewModel;

namespace NEPATechDotnetCoreMVC.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index(ContactViewModel contactModel)
        {
            var name = contactModel.fullName;
            return View();
        }
        public IActionResult eventsRedirect()
        {
            return Redirect("https://www.meetup.com/NEPATech/events/past/");
        }
    }
}