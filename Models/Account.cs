using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWalletSystem.Models
{
    public class Account
    {
        public int Accountid { get; set; }

        public double TotalBalance { get; set; }

        public int Registerid { get; set; }
        public Register Register { get; set; }
    }
}
