using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestionSee.DB;

namespace QuestionSee.Controllers
{
    public class AccountController : Controller
    {

        DBConnection db;
        Session ses;

        public AccountController(DBConnection db, Session ses)
        {
            this.db = db;
            this.ses = ses;
        }

        public ActionResult T()
        {
            string sid = HttpContext.Session.Id;
            if (ses.users.ContainsKey(sid)) ;
                //Пользователь есть
            else;
            //Пользователя нет
            ses.users[sid] = new SessionElement() { UserId = 44 };

            var current = ses.users[sid];
            current.UserId = 123;

            return View();
        }


        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult LogOff()
        {

            HttpContext.Session.Id;
            return Redirect("/");
        }


        public ActionResult CheckInfo()
        {
            if (Request.Method != "POST")
            {
                return Json(new { error = "НЕ ПОСТ" });
            }

            string email = Request.Form["EmailCheckLogIn"];
            string password = Request.Form["PasswordCheckLogIn"];
            var em = db.Users.Where(f => f.Email == email).FirstOrDefault();

            if (em == null)
            {
                return View("Test1", "Такого пользователя нет");
            }

            if (em.Password != password)
            {
                return View("Test1", "Пароль неверен");
            }

            HttpContext.Session.Set("test", new byte[] { 0 });
            string sid = HttpContext.Session.Id;
            ses.users[sid] = new SessionElement() { UserNickname = em.Nickname, UserId = em.id };

            return View("Test1", "");

        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
                User u = new User();
                //u.Name = Request.Form["Name"]; старый метод
                u.Name = collection["Name"];
                u.Nickname = collection["Nickname"];
                u.Password = collection["Password"]; 
                u.SecondName = collection["SecondName"];
                u.ProfilePicture = collection["ProfilePicture"];
                u.Email = collection["Email"];

                string vrfpass = collection["PasswordCnf"];

                if(vrfpass != u.Password)
                {
                    return View("RegistrationError", "Введённые пароли не совпадают");
                }

                if (u.Nickname == "" || u.Nickname == null)
                {
                    return View("RegistrationError", "Вы не ввели никнейм");
                }
                
                var emlcheck = db.Users.Where(f => f.Email == u.Email).FirstOrDefault();

                if (emlcheck != null)
                {
                    return View("RegistrationError", "Пользователь с таким Email адресом уже существует");
                }
                var Nicknamecheck = db.Users.Where(f => f.Nickname == u.Nickname).FirstOrDefault();

                if (Nicknamecheck != null)
                {
                    return View("RegistrationError", "Пользователь с таким Nickname'ом уже существует");
                }



                db.Users.Add(u);
                db.SaveChanges();

                return View("RegistrationError", "");
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}