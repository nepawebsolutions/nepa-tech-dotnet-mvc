using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NEPATechDotnetCoreMVC.ViewModel.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "hello"), EmailAddress, MaxLength(256), Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required, EmailAddress, MaxLength(256), Display(Name = "Confirm Email Address"),Compare(nameof(Email),ErrorMessage = "Emails don't match!")]
        public string ConfirmEmail { get; set; }
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required, MinLength(8), DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }
        [Required, MinLength(8), DataType(DataType.Password), Display(Name = "Confirm Password")]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
       
        public List<string> Skills { get; set; }
        public bool IsRegisterSuccessful { get; set; }
    }
}
