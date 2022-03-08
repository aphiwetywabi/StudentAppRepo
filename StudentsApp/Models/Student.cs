using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsApp.Models
{
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }
        public int StudentID { get; set; }

        public string StudentNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}