using Login_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login_System.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }
        //Get: Logout
        public ActionResult Logout()
        {
            Session.Contents.RemoveAll();
            Session.Abandon();
            TempData["Logout"] = "<p class=\"alert alert-warning\">User has been logged out</p>";
            return RedirectToAction("Index", "Login");
        }
    }
}