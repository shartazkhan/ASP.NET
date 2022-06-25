using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationJune5b.Models;

namespace WebApplicationJune5b.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            List<Student> students = new List<Student>();

            for (int i = 0; i < 10; i++)
            {
                /*
                 * Student s = new Student();
                 * s.Id = i+1;
                 * s.Name = "Student " + (i+1),
                 * s.Dob = "";
                 * students.Add(s);
                 */
                students.Add(new Student()
                {
                    Id = "xx-xxxxx-xx",
                    Name = "Student ",
                    Dob = "12-12-1999"
                });
            }
            return View(students);
        }

        [HttpGet]
        public ActionResult Info( )
        { 
            return View();
        }

        [HttpPost]
        public ActionResult Info(Student st)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Submit");
            }
            return View(st);

        }

        public ActionResult Submit()
        {
            Student student1 = new Student();

            student1.Name = Request["Name"];
            student1.Id = Request["Id"];
            student1.Dob = Request["Dob"];
           
            return View(student1);

        }

    }
}