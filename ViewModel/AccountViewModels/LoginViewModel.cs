using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NEPATechDotnetCoreMVC.ViewModel.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="roof")]
        [EmailAddress]
        public String Email { get; set; }

        [Required(ErrorMessage = "roof")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
               
        public bool RememberMe { get; set; }
    }
}
