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

namespace QuestionSee.Controllers
{
    public class HomeController : Controller
    {
        Session ses;
        User CurrentUser;

        public HomeController(Session ses)
        {
            this.ses = ses;
            if (ses.users.Keys.Contains(HttpContext.Session.Id))
            {
                CurrentUser = ses.users[HttpContext.Session.Id].current;
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AccInfo()
        {
            if (CurrentUser != null)
            {

                return View("AccInfo", CurrentUser);

            }

            return View();
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
