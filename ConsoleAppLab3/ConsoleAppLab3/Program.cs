using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hallo, World");
            int[] nums = new int[] { 10, 12, 50, 60, 70 };

            var s1 = new Student();
            var s2 = new Student();
            var s3 = new Student();
            var s4 = new Student();
            var s5 = new Student();

            s1.cgpa = 2.5;
            s2.cgpa = 2.9;
            s3.cgpa = 3.4;
            s4.cgpa = 3.7;
            s5.cgpa = 3.9;

            s1.id = 10;
            s2.id = 12;
            s3.id = 18;
            s4.id = 20;
            s5.id = 21;

            s1.name = "jhon";
            s2.name = "ron";
            s3.name = "don";
            s4.name = "linda";
            s5.name = "alic";

            s1.dob = DateTime.Parse("1999-12-12");
            s2.dob = DateTime.Parse("1996-12-12");
            s3.dob = DateTime.Parse("1990-12-12");
            s4.dob = DateTime.Parse("2019-12-12");
            s5.dob = DateTime.Parse("2021-12-12");


            List<Student> students = new List<Student>();

            students.Add(s1);
            students.Add(s2);
            students.Add(s3);
            students.Add(s4);
            students.Add(s5);



            // To convert from INumarable to arra use .ToArray()

            var filter = (from n in nums where n > 40 select n).ToArray();


            var t1 = (from n in students where n.cgpa > 3.00 select n).ToList();

            var t2 = (from n in students where n.cgpa > 2.5 && n.id > 3 select n).ToList();

            var t3 = (from n in students where (DateTime.Today.Year - (n.dob).Year) > 18 select n).ToList();

            var t4 = (from n in students select new { n.id, n.cgpa } ).ToList();

            var t5 = (from n in students where (DateTime.Today.Year - (n.dob).Year) < 16 select new { n.dob, n.name }).ToList(); 


            for (int i = 0; i < t.Count; i++)
            {
                Console.WriteLine(t[i]);
            }

        }
    }

    class Student
    {
        // prop double tab to generate property 
        public string name { get; set; }
        public DateTime dob { get; set; }
        public int id { get; set; }
        public double cgpa { get; set; }

       

    }


    
}
