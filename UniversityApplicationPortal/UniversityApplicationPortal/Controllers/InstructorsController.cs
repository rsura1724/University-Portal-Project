using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using UniversityApplicationPortal.Core.Models;
using UniversityApplicationPortal.Core.ViewModels;
using UniversityApplicationPortal.Persistance;

namespace UniversityApplicationPortal.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstructorsController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult CreateInstructor()
        {

            var viewModel = new InstructorFormViewModel
            {
                Departments = _context.Departments.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateInstructor(InstructorFormViewModel viewModel)
        {
            var instructor = new Instructor
            {
                InstructorName = viewModel.InstructorName,
                Designation = viewModel.Designation,
                DepartmentId = viewModel.Department
            };
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
            return RedirectToAction("Display", "Instructors");
        }

        public ActionResult Display()
        {
            var instructors = _context.Instructors.Include(s => s.Department).ToList();
            return View(instructors);
        }


        [Authorize]
        public ActionResult EditInstructor(int id)
        {
            var userId = User.Identity.GetUserId();
            var instructor = _context.Instructors.Single(s => s.Id == id);


            var viewModel = new InstructorFormViewModel
            {
                Id = instructor.Id,
                InstructorName = instructor.InstructorName,
                Designation = instructor.Designation,



                Departments = _context.Departments.ToList()

            };
            return View("CreateInstructor", viewModel);
        }


        [Authorize]
        [HttpPost]
        public ActionResult Update(InstructorFormViewModel viewModel)
        {

            //var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);


            if (!ModelState.IsValid)
            {
                viewModel.Departments = _context.Departments.ToList();
                return View("CreateInstructor", viewModel);
            }

            // var course = _context.Courses.Single(c => c.Id == viewModel.Id);
            var instructor = _context.Instructors.Single(c => c.Id == viewModel.Id);
            instructor.InstructorName = viewModel.InstructorName;
            instructor.Designation = viewModel.Designation;

            instructor.DepartmentId = viewModel.Department;

            _context.SaveChanges();
            return RedirectToAction("Display", "Instructors");

        }

        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = _context.Instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // POST: Home/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var instructor = _context.Instructors.Single(s => s.Id == id);



            _context.Instructors.Remove(instructor);
            _context.SaveChanges();
            return RedirectToAction("Display", "Instructors");
        }



    }
}