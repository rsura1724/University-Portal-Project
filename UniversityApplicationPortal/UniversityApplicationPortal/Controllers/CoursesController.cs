using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using UniversityApplicationPortal.Core.Models;
using UniversityApplicationPortal.Core.ViewModels;
using UniversityApplicationPortal.Persistance;

namespace UniversityApplicationPortal.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult CreateCourse()
        {

            var viewModel = new CourseFormViewModel
            {
                Departments = _context.Departments.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateCourse(CourseFormViewModel viewModel)
        {
            var course = new Course
            {
                CourseName = viewModel.CourseName,
                DepartmentId = viewModel.Department
            };
            _context.Courses.Add(course);
            _context.SaveChanges();
            return RedirectToAction("Display", "Courses");
        }



        public ActionResult Display()
        {
            var courses = _context.Courses.Where(s => s.IsCanceled == false).Include(s => s.Department).ToList();
            return View(courses);
        }


        [Authorize]
        public ActionResult EditCourse(int id)
        {
            var userId = User.Identity.GetUserId();
            var course = _context.Courses.Single(s => s.Id == id);


            var viewModel = new CourseFormViewModel
            {
                Id = course.Id,
                CourseName = course.CourseName,
                
                

                Departments = _context.Departments.ToList()

            };
            return View("CreateCourse", viewModel);
        }


        [Authorize]
        [HttpPost]
        public ActionResult Update(CourseFormViewModel viewModel)
        {

            //var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);


            if (!ModelState.IsValid)
            {
                viewModel.Departments = _context.Departments.ToList();
                return View("CreateCourse", viewModel);
            }

           // var course = _context.Courses.Single(c => c.Id == viewModel.Id);
            var course = _context.Courses.Single(c => c.Id == viewModel.Id );
            course.CourseName = viewModel.CourseName;
            
            course.DepartmentId = viewModel.Department;

            _context.SaveChanges();
            return RedirectToAction("Display", "Courses");

        }
    }
}