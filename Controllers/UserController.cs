using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using T1807MVC.Models;

namespace T1807MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Store(User user)
        {
            var jsonUser = JsonConvert.SerializeObject(user);
            Debug.WriteLine(jsonUser);
            ViewBag.user = user;
            return View();
        }
    }
}