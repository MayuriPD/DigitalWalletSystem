using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DigitalWalletSystem.ViewModels
{
    public class Register
    {
        [Required(ErrorMessage ="Enter First name")]
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Enter Email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Enter Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage ="Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Please make sure Password is matching with Confirm Password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
