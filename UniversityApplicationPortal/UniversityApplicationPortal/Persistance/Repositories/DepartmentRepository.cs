using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UniversityApplicationPortal.Core.Models;
using UniversityApplicationPortal.Core.Repositories;

namespace UniversityApplicationPortal.Persistance.Repositories
{
    public class DepartmentRepository : IDepartmentRepository,IDisposable
    {
        private ApplicationDbContext context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }



        public IEnumerable<Department> GetDepartments()
        {
            return context.Departments.ToList();
        }

        public Department GetDepartmentById(int departmentId)
        {
            return context.Departments.Find(departmentId);
        }



        public void InsertDepartment(Department department)
        {
            context.Departments.Add(department);
        }

        public void DeleteDepartment(int departmentId)
        {
            Department department = context.Departments.Find(departmentId);
            context.Departments.Remove(department ?? throw new InvalidOperationException());
        }

        public void UpdateDepartment(Department department)
        {
            context.Entry(department).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}