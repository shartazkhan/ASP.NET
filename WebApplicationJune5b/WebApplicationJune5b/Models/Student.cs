using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationJune5b.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Please provie Id")]
        [RegularExpression(@"^[0-9]{2}-[0-9]{5}-[1-3]{1}$", ErrorMessage = "Invalid ID!")]
        public string Id { get; set; }
        

        [Required(ErrorMessage = "Please enter your name!")]
        [RegularExpression(@"^[a-z A-z.]+$", ErrorMessage = "Invalid Name!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your date of birth!")]
        public string Dob { get; set; }

        [Required(ErrorMessage = "Please provie Email")]
        [EmailAddress(ErrorMessage = "Invalid email!")]
        public string Email { get; set; }
       

        [Required(ErrorMessage = "Please enter your gender!")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter you Department!")]
        public string Dept { get; set; }
    }
}