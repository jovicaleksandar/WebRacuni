using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRacuni.Models;

namespace WebRacuni.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            User loggedIn = HttpContext.Application["loggedIn"] as User;

            if (!loggedIn.loggedIn)
            {
                User user = Session["user"] as User;

                if (user == null)
                {
                    user = new User();
                    Session["user"] = user;
                }

                ViewBag.user = user;

                return View();
            }
            else
                return RedirectToAction("Result");
        }

        public ActionResult Result()
        {
            User user = Session["user"] as User;

            if (user == null)
            {
                user = new User();
                Session["user"] = user;
            }

            ViewBag.user = user;

            return View();
        }

        [HttpPost]
        public ActionResult SignInAutomaticBinding(User login)
        {
            User user = Session["user"] as User;

            if (user == null)
            {
                user = new User();
                Session["user"] = user;
            }

            if (login.username.Equals("Pera") && login.password.Equals("pera"))
            {
                user.username = login.username;
                user.password = login.password;
                user.loggedIn = true;

                Session["user"] = user;
                HttpContext.Application["loggedIn"] = user;
            }

            ViewBag.user = user;

            return RedirectToAction("Index", "Racuni");
        }
        
        public ActionResult SignOff()
        {
            Session.Abandon();
            User user = new User();
            Session["user"] = user;

            HttpContext.Application["loggedIn"] = user;

            return RedirectToAction("Index");
        }
    }
}