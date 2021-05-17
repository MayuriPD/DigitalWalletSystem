using DigitalWalletSystem.EF;
using DigitalWalletSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWalletSystem.Helpers
{
    public class AccountOperations
    {
        public async Task<int> GetAccountIdByUserId(int registerUserId)
        {
            using (var dbContext = new DigitalWalletDbContext())
            {
                var accountrecord = await this.GetAccountInformation(registerUserId);
                return accountrecord.Accountid;
            }
        }

        public async Task<double> GetAccountBalanceByAccountid(int accountId)
        {
            using(var dbContext = new DigitalWalletDbContext())
            {
                var accountInfo = dbContext.Account.Where(m => m.Accountid == accountId).FirstOrDefault();
                var totalbalance= accountInfo.TotalBalance;
                return totalbalance;
            }
        }

        public async Task<double> TransferByID(double transferAmount,int userId,string phoneNumber)
        {
            var updatedBalance = 0.0;
            using(var dbContext = new DigitalWalletDbContext())
            {
                var accountrecord = await this.GetAccountInformation(userId);
                accountrecord.TotalBalance -= transferAmount;
                if (accountrecord.TotalBalance < 0)
                {
                    throw new Exception("Insufficient account balance! Please deposit and try again.");
                }

                dbContext.Account.Update(accountrecord);

                var registerRecord = dbContext.Register.Where(l => l.PhoneNumber == (Convert.ToString(phoneNumber))).FirstOrDefault();
                var  transferRecordId = registerRecord.RegisterId;
                var accountInfo = dbContext.Account.Where(m => m.Accountid == transferRecordId).FirstOrDefault();
                accountInfo.TotalBalance += transferAmount;
                
                dbContext.Account.Update(accountInfo);
                await dbContext.SaveChangesAsync();
                updatedBalance = accountrecord.TotalBalance;
            }

            return updatedBalance;
        }

        public async Task<double> DepositByID(int userId, double depositAmount)
        {
            var updatedBalance = 0.0;
            using (var dbContext = new DigitalWalletDbContext())
            {
                var accountrecord = await this.GetAccountInformation(userId);
                accountrecord.TotalBalance += depositAmount;
                dbContext.Account.Update(accountrecord);
                await dbContext.SaveChangesAsync();
                updatedBalance = accountrecord.TotalBalance;
            }

            return updatedBalance;
        }


        public async Task<Account> GetAccountInformation(int regid)
        {
            using(var dbContext= new DigitalWalletDbContext())
            {
                var accountInfo = dbContext.Account.Where(m => m.Registerid == regid).FirstOrDefault();
                
                return accountInfo;
            }

        }

    }
}
