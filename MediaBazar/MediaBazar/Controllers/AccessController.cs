using MediaBazar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MediaBazar.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User model)
        {
            var db = new MovieWalaDbEntities();
            var usr = (from s in db.Users
                       where s.Username.Equals(model.Username)
                       && s.Password.Equals(model.Password)
                       select s).SingleOrDefault();
            if (usr != null)
            {
                if ("Consumer"== usr.Type)
                {
                    Session["logged_user"] = usr.Username;
                    FormsAuthentication.SetAuthCookie(usr.Username, false);
                    Session["role"] = usr.Type;
                    return RedirectToAction("Index", "Dashboard");
                }
                if ("Admin" == usr.Type)
                {
                    Session["logged_user"] = usr.Username;
                    FormsAuthentication.SetAuthCookie(usr.Username, false);
                    Session["role"] = usr.Type;
                    return RedirectToAction("AdminIndex", "Dashboard");
                }

            }

            //if (model.Username == null && model.Password == null )
            // {
            TempData["Msg"] = "Username or Password is invalid";
            //}

            return View();

        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Consumer cu)
        {


            if (ModelState.IsValid)
            {
                MovieWalaDbEntities db = new MovieWalaDbEntities();
                //var user = (from n in db.Userlists select n).FirstOrDefault();
                //return View(news);

                
                db.Consumers.Add(cu);
                db.SaveChanges();
                return RedirectToAction("UP");
            }
            else
            {
                TempData["Msg"] = "Invalid information!";
                return View();
            }


        }

        [HttpGet]
        public ActionResult UP()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UP(User nu)
        {
            if (ModelState.IsValid)
            {
                var db = new MovieWalaDbEntities();
                var user = (from n in db.Users select n).FirstOrDefault();
                //return View(news);

                nu.Type = "Consumer";
                db.Users.Add(nu);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                TempData["Msg"] = "Invalid information!";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("logged_user");
            return RedirectToAction("Index");
            Session.RemoveAll();
        }
    }
}