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
            //if (!Request.Form.ContainsKey("SearchByHeader") || !Request.Form.ContainsKey("SearchByTags"))
            //{
            //    return View("empty");
            //}

            string head = null; 
            string tags = null; 

            if (Request.Method == "POST")
            {
                head = Request.Form["SearchByHeader"];
                tags = Request.Form["SearchByTags"];
            }

            var arr = db.Questions.AsQueryable();

            if (!string.IsNullOrWhiteSpace(head))
            {
                arr = arr.Where(f => f.Header.Contains(head));
            }

            if (!string.IsNullOrWhiteSpace(tags))
            {
                var qtags = tags.Split(',');
                //foreach(var d in qtags)
                arr = arr.Where(f => qtags.Contains(f.Tag));
            }

            return View(arr.ToArray());
        }
    }
}

