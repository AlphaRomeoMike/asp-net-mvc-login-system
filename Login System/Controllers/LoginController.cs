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
            var user = db.Users.Where(model => model.Email == u.Email && model.Password == u.Password).FirstOrDefault();

            if(user != null)
            {
                Session["UserId"] = u.Id.ToString();
                //Session["UserName"] = u.Firstname.ToString();
                Session["User"] = u.Id.ToString();
                TempData["Login"] = "<p class=\"alert alert-success\">Login successful</p>";
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.Error = "<p class=\"alert alert-danger\">Login failed! Pelase try again</p>";
                return View();
            }
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