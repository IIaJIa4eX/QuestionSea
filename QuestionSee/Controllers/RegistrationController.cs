using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestionSee.DB;

namespace QuestionSee.Controllers
{
    public class RegistrationController : Controller
    {
        DBConnection db;
        public RegistrationController(DBConnection db)
        {
            this.db = db;
        }

        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        // GET: Registration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Registration/Create
        public ActionResult Create()
        {
            return View(new User());
        }

        // POST: Registration/Create
        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                User u = new User();
                //u.Name = Request.Form["Name"]; старый метод
                u.Name = collection["Name"];
                u.Nickname = collection["Nickname"];
                u.Password = collection["Password"];
                u.SecondName = collection["SecondName"];
                u.ProfilePicture = collection["ProfilePicture"];
                u.Email = collection["Email"];

                db.Users.Add(u);
                db.SaveChanges();

                return Redirect("/");
                // TODO: Add insert logic here

                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                
            }

            return View();
        }

        // GET: Registration/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Registration/Edit/5
        [HttpPost]
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

        // GET: Registration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Registration/Delete/5
        [HttpPost]
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