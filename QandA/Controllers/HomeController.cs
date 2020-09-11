using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QandA.Data;
using QandA.Models;

namespace QandA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QandAContext _aContext;

        public HomeController(ILogger<HomeController> logger,QandAContext aContext )
        {
            _logger = logger;
            _aContext = aContext;
        }

        public IActionResult Index()
        {
            List<Question> questions = _aContext.Questions.Include(u => u.User).ToList();
            return View(questions);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Ask()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Ask(AskQuestionModel askQuestionModel)
        {
            if (!ModelState.IsValid)
            {
                return View(askQuestionModel);
            }

            Question q = new Question();
            q.DateCreated = DateTime.Now;
            q.Title = askQuestionModel.Title;
            q.Description = askQuestionModel.Content;
            q.UserId = 1;

            _aContext.Questions.Add(q);
            _aContext.SaveChanges();

            
            ModelState.Clear();
            ViewBag.SuccessMessage = "Data was saved";
            return View();
           // return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
