using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWalletSystem.Models
{
    public class LoginHistory
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int RegisterId { get; set; }
        public Register Register { get; set; }
    }
}
