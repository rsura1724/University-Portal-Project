using System.Collections.Generic;
using UniversityApplicationPortal.Core.Models;

namespace UniversityApplicationPortal.Core.ViewModels
{
    public class CourseFormViewModel
    {
        public string CourseName { get; set; }
        public int Department { get; set; }
        public IEnumerable<Department> Departments { get; set; }

        public string Action
        {
            get { return (Id != 0) ? "Update" : "CreateCourse"; }
        }

        public int Id { get; set; }
    }
}