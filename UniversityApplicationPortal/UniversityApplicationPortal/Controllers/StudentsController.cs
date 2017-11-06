using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using UniversityApplicationPortal.Core;
using UniversityApplicationPortal.Core.Models;
using UniversityApplicationPortal.Core.ViewModels;
using UniversityApplicationPortal.Persistance;

namespace UniversityApplicationPortal.Controllers
{
    public class StudentsController : Controller
    {
        // private readonly StudentRepository _studentRepository;
       // private readonly DepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        
        public StudentsController(IUnitOfWork unitOfWork)
        {
            // _studentRepository = new StudentRepository(_context);
            // _departmentRepository = new DepartmentRepository(_context); // Shifted to unitOfWork


            _unitOfWork = unitOfWork;
        }


        [Authorize]
        public ActionResult Create()
        {
           

            var viewModel = new StudentFormViewModel
            {
                // Departments =  _context.Departments.ToList(),
                Departments =  _unitOfWork.Departments.GetDepartments().ToList(),
                Heading = "Add a Student"
            };
            return View("StudentForm",viewModel);
        }



        public ActionResult Display()
        {
           // var students = _context.Students.Include(s => s.Department).ToList();
            var students = _unitOfWork.Students.GetStudents().ToList();
            return View(students);
        }



        

        [Authorize]
        [HttpPost]
        public ActionResult Create(StudentFormViewModel viewModel)
        {

            //var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);


            if (!ModelState.IsValid)
            {
               // viewModel.Departments = _context.Departments.ToList();
                viewModel.Departments = _unitOfWork.Departments.GetDepartments().ToList();
                return View("StudentForm",viewModel);
            }

            var student = new Student
            {
               StudentUserId = User.Identity.GetUserId(),
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                MobileNumber = viewModel.MobileNumber,
                DepartmentId = viewModel.Department,
                

            };
           // _context.Students.Add(student);
           _unitOfWork.Students.InsertStudent(student);
            //_context.SaveChanges();
          //  _studentRepository.Save();
          _unitOfWork.Complete();
            return RedirectToAction("Display", "Students");

        }




        [Authorize]
        public ActionResult EditStudent(int id)
        {
            var userId = User.Identity.GetUserId();
           // var student = _context.Students.Single(s => s.Id == id );
            var student = _unitOfWork.Students.GetStudentById(id);


            var viewModel = new StudentFormViewModel
            {
                Heading = "Update Student Information",
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                MobileNumber = student.MobileNumber,

               // Departments = _context.Departments.ToList()
               Departments = _unitOfWork.Departments.GetDepartments().ToList()

            };
            return View("StudentForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Update(StudentFormViewModel viewModel)
        {

            //var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);


            if (!ModelState.IsValid)
            {
                //viewModel.Departments = _context.Departments.ToList();
                viewModel.Departments = _unitOfWork.Departments.GetDepartments().ToList();
                return View("StudentForm", viewModel);
            }

           // var student = _context.Students.Single(s => s.Id==viewModel.Id);
            var student = _unitOfWork.Students.GetStudentById(viewModel.Id);
            student.FirstName = viewModel.FirstName;
            student.LastName = viewModel.LastName;
            student.MobileNumber = viewModel.MobileNumber;
            student.DepartmentId = viewModel.Department;
            
           // _context.SaveChanges();
          // _studentRepository.Save();
          _unitOfWork.Complete();
            return RedirectToAction("Display", "Students");

        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
           // Student student = _context.Students.Find(id);
            Student student = _unitOfWork.Students.GetStudentById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Home/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //var student = _context.Students.Single(s => s.Id == id);
            var student = _unitOfWork.Students.GetStudentById(id);
            

            
           // _context.Students.Remove(student);
           _unitOfWork.Students.DeleteStudent(student.Id);
            //_context.SaveChanges();
           // _studentRepository.Save();
           _unitOfWork.Complete();
            return RedirectToAction("Display","Students");
        }

    }
    }