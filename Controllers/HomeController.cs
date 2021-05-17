using DigitalWalletSystem.Helpers;
using DigitalWalletSystem.Models;
using DigitalWalletSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWalletSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RegisterOperations registerOperations;
        private readonly LoginOperations loginOperations;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            registerOperations = new RegisterOperations();
            loginOperations = new LoginOperations();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(ViewModels.Register register)
        {
            var registerModel = new Models.Register();
            registerModel.Email = register.Email;
            registerModel.Password = register.Password;
            registerModel.UserName = register.UserName;
            registerModel.PhoneNumber = register.PhoneNumber;
            await registerOperations.InsertRecord(registerModel);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.IsUserLoggedIn = false;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            var registeredUser = await loginOperations.GetRegisteredUserByLogin(login);
            var loginResult = await loginOperations.IsValidLogin(login, registeredUser);

            if (loginResult == true)
            {
                HttpContext.Session.SetString("UserName", registeredUser.UserName);
                HttpContext.Session.SetString("UserId", Convert.ToString(registeredUser.RegisterId));
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewBag.LoginFailureMessage = "Invalid Username or Password! Please try again.";
                return View();
            }
        }

        public ActionResult Logout()
        {
            ViewBag.IsUserLoggedIn = false;
            return View("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
                           