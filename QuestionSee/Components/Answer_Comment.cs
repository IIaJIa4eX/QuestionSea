using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuestionSee.DB;
namespace QuestionSee.Components
{
    public class AnswerCommentsViewComponent : ViewComponent
    {
        DBConnection db;
        public AnswerCommentsViewComponent(DBConnection db)
        {
            this.db = db;
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

            string id = Request.Form["AnswersComments"];
            int iid = int.Parse(id);
            var arr = db.Answers.Where(f => f.QuestionId == iid).ToArray();


            return View(arr);
        }
    }
}

