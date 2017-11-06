using UniversityApplicationPortal.Core.Repositories;

namespace UniversityApplicationPortal.Core
{
    public interface IUnitOfWork
    {
        IDepartmentRepository Departments { get; }
        IStudentRepository Students { get; }

        void Complete();
    }
}