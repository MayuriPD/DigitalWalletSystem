using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DigitalWalletSystem.ViewModels
{
    public class Login
    {
        [Required(ErrorMessage = "Enter the Phonenumber or Email")]
        public string Input { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
