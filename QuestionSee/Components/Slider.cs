using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestionSee.DB;
namespace QuestionSee.Components
{
    public class SliderViewComponent : ViewComponent
    {

        DBConnection db;
        public SliderViewComponent(DBConnection db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var arr = db.Questions.Take(10).ToArray();

            if (arr == null)
                arr = new Question[0];


            return View(arr);
        }
    }
}
