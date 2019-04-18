using Microsoft.AspNetCore.Mvc;
using QuestionSee.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionSee.Components
{
    public class QuestionsFlowViewComponent : ViewComponent
    {
        DBConnection db;


        public QuestionsFlowViewComponent(DBConnection db)
        {
            this.db = db;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {

            var arr = db.Questions.ToArray();

            return View(arr);
        }
    }
}
