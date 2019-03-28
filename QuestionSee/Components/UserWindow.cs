using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using QuestionSee.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionSee.Components
{
    public class UserWindowViewComponent: ViewComponent
    {
        DBConnection db;
        public UserWindowViewComponent(DBConnection db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int? userID = HttpContext.Session.GetInt32("UserID");
            if (userID == null)
            {
                return View("Register");
            }

            var user = db.Users.Where(f => f.id == userID).FirstOrDefault();

            if (user == null)
                return View("Register");

            return View("User", user);
        }
    }
}
