
using StudentsApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentsApp.Infustructure
{
    public class StudentCourseDBContext : DbContext
    {

        public StudentCourseDBContext()
           : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
        public StudentCourseDBContext(string Constring)
            : base(Constring)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static StudentCourseDBContext Create(string Constring)
        {
            return new StudentCourseDBContext();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}