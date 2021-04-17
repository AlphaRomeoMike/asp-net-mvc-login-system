using Login_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login_System.Controllers
{
    public class LoginController : Controller
    {
        LoginEntities db = new LoginEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User u)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(User u)
        {
            if(ModelState.IsValid == true)
            {
                db.Users.Add(u);
                int a = db.SaveChanges();
                if(a > 0)
                {
                    TempData["Signup"] = "<p class=\"alert alert-success\">User registered successfully</p>";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Signup"] = "<p class=\"alert alert-danger\">User registration failed</p>";
                }
            }
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }
    }
}