using DigitalWalletSystem.EF;
using DigitalWalletSystem.Models;
using DigitalWalletSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWalletSystem.Helpers
{
    public class LoginOperations
    {

        public async Task<Models.Register> GetRegisteredUserByLogin(Login login)
        {
            using (var dbContext = new DigitalWalletDbContext())
            {
                var user = dbContext.Register.Where(l => string.Equals(l.Email, login.Input) || string.Equals(l.PhoneNumber, login.Input)).SingleOrDefault();
                if (user != null)
                {
                    return user;
                }

                return null;
            }
        }

        public async Task<bool> IsValidLogin(Login login, Models.Register user)
        {
            using (var dbContext = new DigitalWalletDbContext())
            {
                if (user != null)
                {
                    if (string.Equals(user.Password, login.Password))
                    {
                        var loginHistory = new LoginHistory();
                        loginHistory.Email = user.Email;
                        loginHistory.PhoneNumber = user.PhoneNumber;
                        loginHistory.RegisterId = user.RegisterId;
                        dbContext.LoginHistory.Add(loginHistory);
                        await dbContext.SaveChangesAsync();
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
