using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NEPATechDotnetCoreMVC.ViewModel;

namespace NEPATechDotnetCoreMVC.Controllers
{
    public class MembersController : Controller
    {
        [HttpGet]
        public IActionResult Index(int? page)
        {
            var dummyMembers = Enumerable.Range(1, 150).Select(x => "Android #" + x);
            var pager = new Pager(dummyMembers.Count(), page);
            Random random = new Random();

            var viewModel = new MembersViewModel {

                Members = dummyMembers.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager,
                description = "decidedly descript description of describing a disciple of dionysus for doccumentation determination",
                dateJoined = (random.Next(1, 12)) + "/" +(random.Next(1,28))+"/"+ (random.Next(1991, 2800))
            };
            return View(viewModel);
        }
    }
}