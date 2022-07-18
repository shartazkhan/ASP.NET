using MediaBazar.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediaBazar.Models;
using System.IO;

namespace MediaBazar.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        [LogAuth]
        public ActionResult Index()
        {
            var db = new MovieWalaDbEntities();
            var mv = db.Contents.ToList();
            return View(mv);
            


        }

        [LogAuth]
        public ActionResult Player(int id)
        {
            var db = new MovieWalaDbEntities();
            var cnts = (from n in db.Contents where n.Cid.Equals(id) select n).FirstOrDefault();
            return View(cnts);

        }

        [AdminAuth]
        public ActionResult AdminIndex(Official model)
        {
            
            var db = new MovieWalaDbEntities();
            string value = Session["logged_user"].ToString();
            var usr = (from o in db.Officials where o.Username.Equals(value) select o).SingleOrDefault();

          

            return View(usr);
        }

        [AdminAuth]
       // [HttpGet]
        public ActionResult UserList()
        {
            // var db = new MovieWalaEntities();


            // var usr = (from oo in db.Officials where oo.Username.Equals(usn) select oo).FirstOrDefault();

            var db = new MovieWalaDbEntities();
            var user = db.Officials.ToList();

            //var usr = (from n in db.Officials select n);
            return View(user);


        }

        [AdminAuth]
        public ActionResult ContentList()
        {
            var db = new MovieWalaDbEntities();
            var mv = db.Contents.ToList();


            return View(mv);


        }

        [AdminAuth]
        [HttpGet]
        public ActionResult EditUser (int id)
        {
            var db = new MovieWalaDbEntities();
            var usr1 = (from n in db.Officials where n.Id.Equals(id) select n).FirstOrDefault();
            return View(usr1);
        }

        [AdminAuth]
        [HttpPost]
        public ActionResult EditUser(Official official)
        {
            if (ModelState.IsValid)
            {
                var db = new MovieWalaDbEntities();
                var usr = (from n in db.Officials where n.Id.Equals(official.Id) select n).FirstOrDefault();

                db.Entry(usr).CurrentValues.SetValues(official);
                db.SaveChanges();
                return RedirectToAction("AdminIndex");
            }

            return View();
        }

        [AdminAuth]
        [HttpGet]
        public ActionResult EditContent(int id)
        {
            
            var db = new MovieWalaDbEntities();
            var cnt = (from c in db.Contents where c.Cid.Equals(id) select c).FirstOrDefault();
            return View(cnt);
         
           
        }

        

        [AdminAuth]
        [HttpPost]
        public ActionResult EditContent(Content content, HttpPostedFileBase file)
        {
            
            

            if (ModelState.IsValid)
            {
                var db1 = new MovieWalaDbEntities();
                var cnt1 = (from c1 in db1.Contents where c1.Cid.Equals(content.Cid) select c1).FirstOrDefault();

                db1.Entry(cnt1).CurrentValues.SetValues(content);
                db1.SaveChanges();
                return RedirectToAction("AdminIndex", "Dashboard");
            }

            return View();
        }


        [AdminAuth]
        [HttpGet]
        public ActionResult AddContent()
        {
            return View();
        }


        [AdminAuth]
        [HttpPost]
        public ActionResult AddContent(Content content)
        {


            if (ModelState.IsValid)
            {
                MovieWalaDbEntities db = new MovieWalaDbEntities();
                //var user = (from n in db.Userlists select n).FirstOrDefault();
                //return View(news);


                db.Contents.Add(content);
                db.SaveChanges();
                return RedirectToAction("ContentList");
            }
            else
            {
                TempData["Msg"] = "Invalid information!";
                return View();
            }


        }

        [AdminAuth]
        public ActionResult Delete(int id)
        {
            MovieWalaDbEntities db = new MovieWalaDbEntities();
            var cnt = (from n in db.Contents where n.Cid.Equals(id) select n).FirstOrDefault();
            db.Contents.Remove(cnt);
            db.SaveChanges();
            return RedirectToAction("ContentList");
        }

        [AdminAuth]
        public ActionResult DeleteO(int id)
        {
            MovieWalaDbEntities db = new MovieWalaDbEntities();
            var usr1 = (from n in db.Officials where n.Id.Equals(id) select n).FirstOrDefault();
            db.Officials.Remove(usr1);
            db.SaveChanges();

            var usr2 = (from n in db.Users where n.Sl.Equals(id) select n).FirstOrDefault();
            db.Users.Remove(usr2);
            db.SaveChanges();

            return RedirectToAction("UserList");
        }

        [AdminAuth]
        public ActionResult DeleteC(int id)
        {
            MovieWalaDbEntities db = new MovieWalaDbEntities();
            var usr1 = (from n in db.Consumers where n.Id.Equals(id) select n).FirstOrDefault();
            db.Consumers.Remove(usr1);
            db.SaveChanges();

            var usr2 = (from n in db.Users where n.Sl.Equals(id) select n).FirstOrDefault();
            db.Users.Remove(usr2);
            db.SaveChanges();

            return RedirectToAction("UserList");
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(Official official)
        {


            if (ModelState.IsValid)
            {
                MovieWalaDbEntities db = new MovieWalaDbEntities();
                //var user = (from n in db.Userlists select n).FirstOrDefault();
                //return View(news);


                db.Officials.Add(official);
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


    }
}