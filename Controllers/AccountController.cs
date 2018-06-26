﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NEPATechDotnetCoreMVC.ViewModel;

namespace NEPATechDotnetCoreMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            RegisterViewModel register = new RegisterViewModel();
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View(register);
        }

    }
}