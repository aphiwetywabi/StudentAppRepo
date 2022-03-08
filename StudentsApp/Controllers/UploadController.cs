using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IronXL;
using StudentsApp.Infustructure;
using StudentsApp.Models;

namespace StudentsApp.Controllers
{
    public class UploadController : Controller
    {
        private StudentCourseDBContext db = new StudentCourseDBContext();
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> UploadFile(HttpPostedFileBase file)
        {
            try
            {
               
                string _FileName = Path.GetFileName(file.FileName);
                string extension = Path.GetExtension(_FileName);
                var studentModel = new List<Student>();
                var CourseModel = new List<Course>();


                if (file.ContentLength > 0)
                {
                    if (extension == ".xlsx" || extension == ".CSV")
                    {
                        string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                        var column1 = new List<string>();
                        var column2 = new List<string>();
                    
                        file.SaveAs(_path);

                        int count = 0;

                        using (var rd = new StreamReader(_path))
                        {
                           while (!rd.EndOfStream)
                           {
                                var splits = rd.ReadLine().Split(';');
                                column1.Add(splits[0]);
                                column2.Add(splits[1]);

                                if (count > 0)
                                {
                                    var student = new Student();
                                    var course = new Course();

                                   student.StudentNumber = splits[0];
                                   student.FirstName = splits[1];
                                   student.LastName = splits[2];

                                    course.CourseCode = splits[3];
                                    course.CourseDescription = splits[4];
                                    course.Grade = splits[5];

                                    student.Courses.Add(course);

                                    db.Students.Add(student);
                                    await db.SaveChangesAsync();

                                }
                                
                                count++;
                            }
                        }
                   }
                }
                else
                {
                    ViewBag.Message = "File type is incorrect!!";
                    return View();
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch(Exception ex)
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }
    }
}