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
        Session ses;
        public UserWindowViewComponent(DBConnection db, Session ses)
        {
            this.db = db;
            this.ses = ses;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var SessionID = HttpContext.Session.Id;
            int? userID = null;
            if (ses.users.ContainsKey(SessionID))
            {
                var element = ses.users[SessionID];
                userID = element.UserId;
            }

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
