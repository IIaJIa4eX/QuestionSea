using Microsoft.AspNetCore.Mvc;
using QuestionSee.DB;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionSee.Components
{
    public class UsersListViewComponent : ViewComponent
    {
        DBConnection db;

        User CurrentUser = new DB.User();
        Session ses;

        public UsersListViewComponent(DBConnection db, Session ses)
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

            User u = CurrentUser;

            string Nick = null;
            string Mail = null;

            if (Request.Method == "POST")
            {
                Nick = Request.Form["SearchByNickname"];
                Mail = Request.Form["SearchByEmail"];
            }

            var arr = db.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(Nick))
            {
                arr = arr.Where(f => f.Nickname.Contains(Nick));
            }

            if (!string.IsNullOrWhiteSpace(Mail))
            {

                arr = arr.Where(f => f.Email.Contains(Mail));
            }

            dynamic d = new ExpandoObject();
            d.users = arr.ToArray();
            d.currentuser = u;

            return View(d);
        }
    }
}
