using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QandA.Data;
using QandA.Models;

namespace QandA.Controllers
{
    public class AccountController : Controller
    {
        private readonly QandAContext _dbContext;


        public AccountController(QandAContext aContext)
        {
            _dbContext = aContext;
        }

        public IActionResult SignOut()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SignIn(SignInModel user)
        {
            //TODO: authorize user
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Register(RegisterModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            User u = new User();
            u.Username = user.Username;
            u.Password = user.Password;
           

            _dbContext.Users.Add(u);
            _dbContext.SaveChanges();


            return RedirectToAction("Index", "Home");
        }
    }
}
