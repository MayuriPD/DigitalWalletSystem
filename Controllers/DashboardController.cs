using DigitalWalletSystem.Helpers;
using DigitalWalletSystem.Models;
using DigitalWalletSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWalletSystem.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AccountOperations accountOperations;
        private static string loggedinuserId;
        private static int accountId;
        public DashboardController()
        {
            this.accountOperations = new AccountOperations();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // set login user to true
            ViewBag.IsUserLoggedIn = true;

            // set user name, user id
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            loggedinuserId = HttpContext.Session.GetString("UserId");

            // get account id
            accountId = await accountOperations.GetAccountIdByUserId(Convert.ToInt32(loggedinuserId));

            // set account id
            ViewBag.AccountId = accountId;

            // get balace for account id
            var balance = await accountOperations.GetAccountBalanceByAccountid(accountId);
            ViewBag.AccountBalance = balance;
            return View();
        }

        [HttpGet]
        public IActionResult Transfer()
        {
            // set account id
            ViewBag.AccountId = accountId;

            return View();
        }

        [HttpGet]
        public IActionResult Deposit()
        {
            // set account id
            ViewBag.AccountId = accountId;

            return View();
        }

        [HttpPost]
        public IActionResult Deposit(DepositAmount depositAmount)
        {
            // set login user to true
            ViewBag.IsUserLoggedIn = true;

            // perform deposit and get updated balance
            var updateBalance = accountOperations.DepositByID(Convert.ToInt32(loggedinuserId), depositAmount.Amount);

            // pass updated balance to UI
            ViewBag.AccountBalance = updateBalance;
            ViewBag.SuccessfulTransfer = "Deposit Successful!";

            // set account id
            ViewBag.AccountId = accountId;
            return View();
        }

        [HttpPost]
        public IActionResult Transfer(TransferAmount transferAmount)
        {
            try
            {
                // set login user to true
                ViewBag.IsUserLoggedIn = true;

                // perform transfer to other user and get updated balance
                var updatedBalance = accountOperations.TransferByID(transferAmount.Amount, Convert.ToInt32(loggedinuserId), transferAmount.PhoneNumber);

                // pass update balance to UI
                ViewBag.AccountBalance = updatedBalance;

                // set account id
                ViewBag.AccountId = accountId;
            }
            catch (Exception ex)
            {
                // Pass error message to UI in case of insufficient balance
                ViewBag.InsufficientAccountBalance = ex.Message;
                return View();
            }

            
            ViewBag.SuccessfulTransfer = "Transfer Successful!";
            return View();
        }
    }
}
