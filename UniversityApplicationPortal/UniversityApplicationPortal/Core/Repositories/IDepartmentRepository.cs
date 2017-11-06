using System.Collections.Generic;
using UniversityApplicationPortal.Core.Models;

namespace UniversityApplicationPortal.Core.Repositories
{
    public  interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartmentById(int studentId);
        void InsertDepartment(Department department);
        void DeleteDepartment(int departmentId);
        void UpdateDepartment(Department department);
        void Save();
    }
}
