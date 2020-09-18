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
        private readonly QandAContext _dbContext;

        public HomeController(QandAContext aContext )
        {
            _dbContext = aContext;
        }

        public IActionResult Index()
        {
            List<Question> questions = _dbContext.Questions.Include(u => u.User).ToList();
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

            _dbContext.Questions.Add(q);
            _dbContext.SaveChanges();

            
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
