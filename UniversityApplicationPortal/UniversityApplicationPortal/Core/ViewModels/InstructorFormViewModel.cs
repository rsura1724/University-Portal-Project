using System.Collections.Generic;
using UniversityApplicationPortal.Core.Models;

namespace UniversityApplicationPortal.Core.ViewModels
{
    public class InstructorFormViewModel
    {
        public string InstructorName { get; set; }
        public string Designation { get; set; }
        public int Department { get; set; }
        public IEnumerable<Department> Departments { get; set; }

        public string Action
        {
            get { return (Id != 0) ? "Update" : "CreateInstructor"; }
        }

        public int Id { get; set; }
    }
}