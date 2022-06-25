using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCV.Controllers
{
    public class CVController : Controller
    {
        // GET: CV
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Personal()
        {
            return View();
        }

        public ActionResult Academic()
        {
            return View();
        }

    }
}