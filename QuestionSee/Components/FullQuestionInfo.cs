using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuestionSee.DB;
namespace QuestionSee.Components
{
    public class FullQuestionInfoViewComponent : ViewComponent
    {
        DBConnection db;

        public FullQuestionInfoViewComponent(DBConnection db)
        {
            this.db = db;
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
            string id = Request.Form["FullQuestionInfo"];
            int iid = int.Parse(id);
            var arr = db.Questions.Where(f => f.Id == iid).FirstOrDefault();


            return View(arr);
        }
    }
}
