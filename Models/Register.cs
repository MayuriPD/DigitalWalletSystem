using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWalletSystem.Models
{
    public class Register
    {
        public int RegisterId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public ICollection<LoginHistory> LoginHistory { get; set; }

        public ICollection<Account> Account { get; set; }
    }
}
