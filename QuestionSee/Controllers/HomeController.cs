using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestionSee.Models;
using QuestionSee.DB;
using Microsoft.AspNetCore.Mvc.Filters;

namespace QuestionSee.Controllers
{
    public class HomeController : Controller
    {
        DBConnection db;
        Session ses;
        User CurrentUser;

        public HomeController(Session ses, DBConnection db)
        {
            this.ses = ses;
            this.db = db;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (ses.users.Keys.Contains(HttpContext.Session.Id))
            {
                CurrentUser = ses.users[HttpContext.Session.Id].current;
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllQuestions()
        {
            
            return View();

        }
        public IActionResult AskQuestion()
        {
            if (CurrentUser != null)
            {

                return View("AskQuestion", CurrentUser);

            }

            return RedirectToAction("RegistrationPage");
        }

        public IActionResult GiveAnswer()
        {
            return
        }



        public IActionResult AccInfo()
        {
            if (CurrentUser != null)
            {

                return View("AccInfo", CurrentUser);

            }

            return RedirectToAction("RegistrationPage");
        }




        public IActionResult RegistrationPage()
        {

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
