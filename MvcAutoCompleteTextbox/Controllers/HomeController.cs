using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAutoCompleteTextbox.Models;

namespace MvcAutoCompleteTextbox.Controllers
{
    public class HomeController : Controller
    {
        private static SampleDBContext db = new SampleDBContext();

        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        [HttpPost]
        public ActionResult Index(string searchTerm)
        {
            List<Student> students;
            if (string.IsNullOrEmpty(searchTerm))
            {
                students = db.Students.ToList();
            }
            else
            {
                students = db.Students.Where(x => x.Name.StartsWith(searchTerm)).ToList();

            }
            return View(students);
            
        }


        public JsonResult GetStudents(string term)
        {
            
            List<string> students = db.Students.Where(s => s.Name.StartsWith(term))
                .Select(x => x.Name).ToList();
            return Json(students, JsonRequestBehavior.AllowGet);
        }


    }
}
