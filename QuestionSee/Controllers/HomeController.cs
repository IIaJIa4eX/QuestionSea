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

      
        public IActionResult AdminActions(IFormCollection collection)
        {
            //var r = Request.Headers.Where(f => f.Key == "HeaderReferer").FirstOrDefault();
            string referer = "";
            foreach (var item in Request.Headers)
            {
                if (item.Key == "Referer")
                {
                    referer = item.Value;
                }
            }

            if (collection["SelectedItem"] == "User ban" || collection["UserId"] != "")
            {
                int id = int.Parse(collection["UserId"]);
                User u = db.Users.Where(f => f.id == id).FirstOrDefault();
                u.Banned = true;

                db.SaveChanges();
            }

            if (collection["SelectedItem"] == "Delete this answer")
            {
                int id = int.Parse(collection["AnswerId"]);
                Answer ans = db.Answers.Where(f => f.id == id).FirstOrDefault();
                ans.Deleted = true;

                db.SaveChanges();
            }


            return Redirect(referer);
        }


        public IActionResult SentQuestion(IFormCollection collection)

        {
            Question qs = new Question();

            int cur;

            if (CurrentUser != null)
            {
                cur = CurrentUser.id;
                User u = db.Users.Where(f => f.id == cur).FirstOrDefault();
                u.Asked++;
                qs.Header = collection["QuestionHeader"];
                qs.Description = collection["content"];
                qs.Tag = collection["QuestionTags"];

                qs.UserId = cur;

                db.Questions.Add(qs);

                GlobalChecker gc = new GlobalChecker();
                gc.QuestionId =

                db.SaveChanges();

                return RedirectToAction("AskQuestion");
            }

            return RedirectToAction("RegistrationPage");

        }

        public IActionResult GiveAnswer(IFormCollection collection)
        {
            int cur;
            if(CurrentUser != null)
            {
                cur = CurrentUser.id;

                User u = db.Users.Where(f => f.id == cur).FirstOrDefault();
                u.Rating = u.Rating +5;
                u.Answered++;

                Answer ans = new Answer();

                ans.AnswerText = collection["content"];
                ans.UserId = cur;
                int id = int.Parse(collection["QuestionId"]);
                ans.QuestionId = id;

                db.Answers.Add(ans);
                db.SaveChanges();

                return RedirectToAction("Index");

            }

            return RedirectToAction("RegistrationPage");
        }

        public IActionResult BestAnswer(IFormCollection collection)
        {
            int iid = int.Parse(collection["BestAnswerId"]);

            Answer ans = db.Answers.Where(f => f.id == iid).FirstOrDefault();

            ans.BestAnswer = true;


            int Questid = ans.QuestionId;

            Question qus = db.Questions.Where(f => f.Id == Questid).FirstOrDefault();

            qus.Answered = true;

            int Usrid = ans.UserId;

            User usr = db.Users.Where(f => f.id == Usrid).FirstOrDefault();

            usr.BestAnswersCount++;

            usr.Rating = usr.Rating + 25;

            db.SaveChanges();

            return RedirectToAction("Index");
        }



        public IActionResult AccInfo()
        {
            if (CurrentUser != null)
            {

                return View("AccInfo", CurrentUser);

            }

            return RedirectToAction("RegistrationPage");
        }

        public IActionResult LikeDislike(IFormCollection collection) {

            
            int QuestionIdLike = int.Parse(collection["Like"]);
            GlobalChecker gb = db.Globals.Where(f => f.QuestionId == QuestionIdLike).FirstOrDefault();

            if(gb != null && gb.IsLiked == true)
            {
                Question qst = db.Questions.Where(f => f.Id == QuestionIdLike).FirstOrDefault();
                qst.Like--;
                qst.Rating = qst.Rating - 10;
                return RedirectToAction("Index");
            }
            
            if(gb.IsLiked == false && gb != null)
            {
                int usid = int.Parse(collection["UserLike"]);
                gb.QuestionId = QuestionIdLike;
                gb.UserId = usid;
                gb.IsLiked = true;

                Question qst = db.Questions.Where(f => f.Id == QuestionIdLike).FirstOrDefault();
                qst.Like++;
                qst.Rating = qst.Rating + 10;

                db.Globals.Add(gb);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            //else
            //{
            //    int QuestionIdDislike = int.Parse(collection["Dislike"]);
            //    Question qst = db.Questions.Where(f => f.Id == QuestionIdDislike).FirstOrDefault();
            //    qst.Dislike++;
            //    qst.Rating = qst.Rating - 10;

            //    db.SaveChanges();
            //}
            return RedirectToAction("Index");
        }

        public IActionResult CheckRandomUserInfo(int id)
        {
            int userid = id;

            if (CurrentUser != null)
            {
                User u = db.Users.Where(f => f.id == userid).FirstOrDefault();

                return View(u);

            }

            return RedirectToAction("RegistrationPage");

        }

        public IActionResult UsersList()
        {

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
