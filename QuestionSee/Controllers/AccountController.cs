using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestionSee.Crypto;
using QuestionSee.DB;

namespace QuestionSee.Controllers
{
    public class AccountController : Controller
    {

        DBConnection db;
        Session ses;

        private IHostingEnvironment _hostingEnvironment;

        public AccountController(DBConnection db, Session ses, IHostingEnvironment environment)
        {
            this.db = db;
            this.ses = ses;
            _hostingEnvironment = environment;
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

            ses.users.Remove(HttpContext.Session.Id);
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

           // password = Md5.Convert(Md5.Convert(password + "SALT_Dp5BZ9raMdFwAHw_SALT")) + Md5.Convert(password + "SALT_Dp5BZ9raMdFwAHw_SALT");

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
            ses.users[sid] = new SessionElement() { UserNickname = em.Nickname, UserId = em.id, current = em };

            return View("Test1", "");

        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
                User u = new User();

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
        public ActionResult Edit(IFormCollection collection)
        {
            int id = int.Parse(collection["Id"]);

            User u = db.Users.Where(f => f.id == id).FirstOrDefault();

            if (u == null)
                return View("EditError", "Пользователь не существует");
            if (!string.IsNullOrWhiteSpace(collection["Name"]))
                u.Name = collection["Name"];
            if (!string.IsNullOrWhiteSpace(collection["Nickname"]))
                u.Nickname = collection["Nickname"];
            if (!string.IsNullOrWhiteSpace(collection["Password"]))
                u.Password = collection["Password"];
            if (!string.IsNullOrWhiteSpace(collection["SecondName"]))
                u.SecondName = collection["SecondName"];
            if (!string.IsNullOrWhiteSpace(collection["Email"]))
                u.Email = collection["Email"];

            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files.First();
                var uploads = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                var filePath = System.IO.Path.Combine(uploads, file.FileName);

                //System.IO.File.OpenWrite(filePath);
                using (var fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
                {
                    file.CopyToAsync(fileStream);
                }

                u.ProfilePicture = "/uploads/" + file.FileName;
            }

            string vrfpass = collection["PasswordCnf"];

            if (!string.IsNullOrWhiteSpace(collection["PasswordCnf"]))
                if (vrfpass != u.Password)
                {
                    return View("EditError", "Введённые пароли не совпадают");
                }

            if (u.Nickname == "" || u.Nickname == null)
            {
                return View("EditError", "Вы не ввели никнейм");
            }

            var emlcheck = db.Users.Where(f => f.Email == u.Email && f.id != u.id).FirstOrDefault();

            if (emlcheck != null)
            {
                return View("EditError", "Пользователь с таким Email адресом уже существует");
            }
            var Nicknamecheck = db.Users.Where(f => f.Nickname == u.Nickname && f.id != u.id).FirstOrDefault();

            if (Nicknamecheck != null)
            {
                return View("EditError", "Пользователь с таким Nickname'ом уже существует");
            }

            db.SaveChanges();

            return View("EditError", "");

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