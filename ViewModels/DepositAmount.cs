using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWalletSystem.ViewModels
{
    public class DepositAmount
    {
        [Required(ErrorMessage = "Enter Amount")]
        public double Amount { get; set; }
    }
}
