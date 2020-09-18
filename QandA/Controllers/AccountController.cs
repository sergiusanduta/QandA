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
            
            return RedirectToAction("Index", "Home");
        }
    }
}
