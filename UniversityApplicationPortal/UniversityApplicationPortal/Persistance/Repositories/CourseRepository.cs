using System.Collections.Generic;
using System.Linq;
using UniversityApplicationPortal.Core.Models;

namespace UniversityApplicationPortal.Persistance.Repositories
{
    public class CourseRepository
    {
        public List<Course> ListOfCourses()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            return context.Courses.ToList();
        }
        public List<Student> ListOfStudents()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            return context.Students.ToList();
        }

       

    }
}