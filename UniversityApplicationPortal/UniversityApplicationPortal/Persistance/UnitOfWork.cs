using UniversityApplicationPortal.Core;
using UniversityApplicationPortal.Core.Models;
using UniversityApplicationPortal.Core.Repositories;
using UniversityApplicationPortal.Persistance.Repositories;

namespace UniversityApplicationPortal.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IStudentRepository Students { get; private set; }
        public IDepartmentRepository Departments { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Students = new StudentRepository(context);
            Departments = new DepartmentRepository(context);

        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}