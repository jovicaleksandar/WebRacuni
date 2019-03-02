using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRacuni.Models;

namespace WebRacuni.Controllers
{
    public class RacuniController : Controller
    {
        // GET: Racuni
        public ActionResult Index()
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
        public ActionResult AddRacun(Racun racun)
        {
            User loggedIn = HttpContext.Application["loggedIn"] as User;

            if (loggedIn.loggedIn)
            {
                User user = Session["user"] as User;

                if (user == null)
                {
                    user = new User();
                    Session["user"] = user;
                }

                if (!user.racuni.collection.Keys.Contains(racun.brojRacuna))
                {
                    racun.ukupnoStanje = racun.rezervisanoStanje + racun.raspolozivoStanje;
                    user.racuni.collection.Add(racun.brojRacuna, racun);
                    Session["user"] = user;
                }
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Uplata(string brojRacuna, double iznos)
        {
            User loggedIn = HttpContext.Application["loggedIn"] as User;

            if (loggedIn.loggedIn)
            {
                User user = Session["user"] as User;

                if (user == null)
                {
                    user = new User();
                    Session["user"] = user;
                }

                user.racuni.collection[brojRacuna].raspolozivoStanje += iznos;
                user.racuni.collection[brojRacuna].ukupnoStanje = user.racuni.collection[brojRacuna].raspolozivoStanje + user.racuni.collection[brojRacuna].rezervisanoStanje;
                Session["user"] = user;

                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Obrisi(string key)
        {
            User loggedIn = HttpContext.Application["loggedIn"] as User;

            if (loggedIn.loggedIn)
            {
                User user = Session["user"] as User;
                if (user == null)
                {
                    user = new User();
                    Session["user"] = user;
                }

                if (user.racuni.collection.Keys.Contains(key))
                    user.racuni.collection.Remove(key);

                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult PromenaStanja(string key)
        {
            User loggedIn = HttpContext.Application["loggedIn"] as User;

            if (loggedIn.loggedIn)
            {
                User user = Session["user"] as User;

                if (user == null)
                {
                    user = new User();
                    Session["user"] = user;
                }

                if (user.racuni.collection.Keys.Contains(key))
                {
                    if (user.racuni.collection[key].aktivan)
                        user.racuni.collection[key].aktivan = false;
                    else
                        user.racuni.collection[key].aktivan = true;
                }

                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index", "Login");
        }
    }
}