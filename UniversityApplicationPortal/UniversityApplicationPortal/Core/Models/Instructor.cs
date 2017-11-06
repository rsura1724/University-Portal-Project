using System.ComponentModel.DataAnnotations;

namespace UniversityApplicationPortal.Core.Models
{
    public class Instructor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string InstructorName { get; set; }
        [Required]
        [StringLength(255)]
        public string Designation { get; set; }

        public Department Department { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}