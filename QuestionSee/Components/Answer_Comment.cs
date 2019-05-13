using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuestionSee.DB;
namespace QuestionSee.Components
{
    public class AnswerCommentsViewComponent : ViewComponent
    {
        DBConnection db;

        User CurrentUser;
        Session ses;

        public AnswerCommentsViewComponent(DBConnection db, Session ses)
        {
            this.db = db;
            this.ses = ses;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (Request.Method != "POST")
            {
                return View("empty");
            }

            if (!Request.Form.ContainsKey("AnswersComments"))
            {
                return View("empty");
            }

            User u = new User();
            CurrentUser = ses.users[HttpContext.Session.Id].current;
            u = CurrentUser;

            string id = Request.Form["AnswersComments"];
            int iid = int.Parse(id);
            var arr = db.Answers.Where(f => f.QuestionId == iid).ToArray();

            dynamic d = new ExpandoObject();
            d.user = u;
            d.answer = arr;

            return View(d);
        }
    }
}

