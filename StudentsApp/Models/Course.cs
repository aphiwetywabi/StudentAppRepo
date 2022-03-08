using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsApp.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        public int StudentID { get; set; }

        public string CourseCode { get; set; }

        public string CourseDescription { get; set; }

        public string Grade { get; set; }

        public virtual Student Student { get; set; }

        
    }
}