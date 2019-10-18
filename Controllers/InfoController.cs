using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace T1807MVC.Controllers
{
    public class InfoController : Controller
    {
        // GET: Info
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(string username, string fullname, string password)
        {
            ViewBag.Username = username;
            ViewBag.Fullname = fullname;
            ViewBag.Password = password;
            return View();
        }
    }
}