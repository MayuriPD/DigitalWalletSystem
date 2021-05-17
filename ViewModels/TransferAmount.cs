using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWalletSystem.ViewModels
{
    public class TransferAmount
    {
        [Required(ErrorMessage ="Enter Amount")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Enter PhoneNumber")]
        public string PhoneNumber { get; set; }


    }
}
