using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using QuestionSee.DB;
namespace QuestionSee.Components
{
    public class AnswerCommentsViewComponent : ViewComponent
    {
        DBConnection db;

        User CurrentUser = new DB.User();
        Session ses;

        public AnswerCommentsViewComponent(DBConnection db, Session ses)
        {
            this.db = db;
            this.ses = ses;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (ses.users.Keys.Contains(HttpContext.Session.Id))
            {
                CurrentUser = ses.users[HttpContext.Session.Id].current;
            }

            if (Request.Method != "POST")
            {
                return View("empty");
            }

            if (!Request.Form.ContainsKey("AnswersComments"))
            {
                return View("empty");
            }

            User u = CurrentUser;

            string id = Request.Form["AnswersComments"];
            int iid = int.Parse(id);
            var arr = db.Answers.Where(f => f.QuestionId == iid).ToArray();

            var quest = db.Questions.Where(f => f.Id == iid).FirstOrDefault();

            

            dynamic d = new ExpandoObject();
            d.user = u;
            d.answer = arr;
            d.currentU = (quest.UserId == CurrentUser.id) ? true : false;

            return View(d);
        }
    }
}

