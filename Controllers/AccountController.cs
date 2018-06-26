using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NEPATechDotnetCoreMVC.Models;

namespace NEPATechDotnetCoreMVC.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string fname,string lname, string email, string confirmEmail, string password, string confirmPassword)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = email, FirstName = fname, LastName = lname, Email = email};
                var result = await _userManager.CreateAsync(user,password);
                if (result.Succeeded)
                {
                    //await SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    
                }
            }

            return View();
        }
    }
}