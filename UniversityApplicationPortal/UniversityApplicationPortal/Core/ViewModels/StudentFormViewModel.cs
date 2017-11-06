using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniversityApplicationPortal.Core.Models;

namespace UniversityApplicationPortal.Core.ViewModels
{
    public class StudentFormViewModel
    {

        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        [Required]
        public int Department { get; set; }
        
        public IEnumerable<Department> Departments { get; set; }

        public string Action
        {
            get { return (Id != 0) ? "Update" : "Create"; }
        }

        public string Heading { get; set; }
    }
}