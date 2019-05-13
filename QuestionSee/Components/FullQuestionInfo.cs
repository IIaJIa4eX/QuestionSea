using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuestionSee.DB;
using QuestionSee.Models;

namespace QuestionSee.Components
{
    public class FullQuestionInfoViewComponent : ViewComponent
    {
        DBConnection db;
        User CurrentUser;
        Session ses;

        public FullQuestionInfoViewComponent(DBConnection db, Session ses)
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

            if (!Request.Form.ContainsKey("FullQuestionInfo"))
            {
                return View("empty");
            }

            User u = new User();
            CurrentUser = ses.users[HttpContext.Session.Id].current;
            u = CurrentUser;
            
            string id = Request.Form["FullQuestionInfo"];
            int iid = int.Parse(id);
            var arr = db.Questions.Where(f => f.Id == iid).FirstOrDefault();

            dynamic d = new ExpandoObject();
            d.user = u;
            d.question = arr;

            //{ user = u, question = arr };

            return View(d);
        }
    }
}
