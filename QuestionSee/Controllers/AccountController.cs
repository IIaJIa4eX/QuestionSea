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

        public AccountController(DBConnection db)
        {
            this.db = db;
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

        public ActionResult Test()
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
                return Json(new { error = "НЕ  ЮЗВЕРЬ" });
            }

            if (em.Password != password)
            {
                return Json(new { error = "НЕ  ПаРоЛь" });
            }

            return Json(new { error = "УРА" });
        }

        public ActionResult Test1()
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

            return View("Test1", "");
        }

        public ActionResult CheckInfo()
        {
            if (Request.Method != "POST")
            {
                return View("empty");
            }

            string email = Request.Form["EmailCheckLogIn"];
            string password = Request.Form["PasswordCheckLogIn"];
            var em = db.Users.Where(f => f.Email == email).FirstOrDefault();

            if (em == null)
            {
                ViewBag.Error = "sdfsdfdsf";
                return View("Registration");// Ошибка 
            }

            if (em.Password != password)
            {
                ViewBag.Error = "sdfsdfdsf";
                return View("Registration"); ; //о
            }

            return RedirectToAction("/Home/Index", em);

        }
        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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