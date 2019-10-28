using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using T1807MVC.Migrations;
using T1807MVC.Models;

namespace T1807MVC.Controllers
{

    public class UserController : Controller
    {
        private static List<User> users = new List<User>();
        private MyDbContext myDbContext;
        public UserController()
        {
            myDbContext = new MyDbContext();
        }
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.userList = myDbContext.Users.ToList();
            return View(ViewBag.userList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            user.id = DateTime.Now.Millisecond;
            myDbContext.Users.Add(user);
            myDbContext.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDbContext, Configuration>());

            for (var i = 0; i < myDbContext.Users.Count(); i++)
            {
                if (myDbContext.Users.ToList()[i].id == id)
                {
                    ViewBag.user = myDbContext.Users.Find(myDbContext.Users.ToList()[i].id);
                }
            }
            return View(ViewBag.user);
        }

        [HttpPut]
        public ActionResult Edit(int id, User updateUser)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDbContext, Configuration>());

            var entity = myDbContext.Users.Find(id);
            myDbContext.Entry(entity).CurrentValues.SetValues(updateUser);
            myDbContext.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDbContext, Configuration>());

            var user = myDbContext.Users.Find(id);
            myDbContext.Users.Remove(user);
            myDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDbContext, Configuration>());

            for (var i = 0; i < myDbContext.Users.Count(); i++)
            {
                if (myDbContext.Users.ToList()[i].id == id)
                {
                    ViewBag.user = myDbContext.Users.Find(myDbContext.Users.ToList()[i].id);
                }
            }
            return View(ViewBag.user);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDbContext, Configuration>());

            for (var i = 0; i < myDbContext.Users.Count(); i++)
            {
                if (myDbContext.Users.ToList()[i].email == email && myDbContext.Users.ToList()[i].password == password)
                {
                    var entity = myDbContext.Users.Find(myDbContext.Users.ToList()[i].id);
                    return new JsonResult()
                    {
                        Data = entity,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
            }
            return null;
        }
    }
}