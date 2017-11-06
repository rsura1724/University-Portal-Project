using System.ComponentModel.DataAnnotations;

namespace UniversityApplicationPortal.Core.Models
{
    public class Student
    {
        public int Id { get; set; }
        
        public ApplicationUser StudentUser { get; set; }

        [Required]
        public string StudentUserId { get; set; }
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(255)]
        public string LastName { get; set; }
        public string MobileNumber { get; set; }

        public Department Department { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}