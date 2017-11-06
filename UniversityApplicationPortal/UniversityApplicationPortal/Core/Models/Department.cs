using System.ComponentModel.DataAnnotations;

namespace UniversityApplicationPortal.Core.Models
{
    public class Department
    {

        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string DepartmentName { get; set; }
    }
}