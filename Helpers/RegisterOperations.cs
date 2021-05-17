using DigitalWalletSystem.EF;
using DigitalWalletSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWalletSystem.Helpers
{
    public class RegisterOperations
    {
        public async Task InsertRecord(Register register)
        {
            using (var dbContext = new DigitalWalletDbContext())
            {
                dbContext.Register.Add(register);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
