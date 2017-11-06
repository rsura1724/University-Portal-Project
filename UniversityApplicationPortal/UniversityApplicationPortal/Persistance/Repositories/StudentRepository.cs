using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UniversityApplicationPortal.Core.Models;
using UniversityApplicationPortal.Core.Repositories;

namespace UniversityApplicationPortal.Persistance.Repositories
{
    public class StudentRepository : IStudentRepository, IDisposable
    {
        private ApplicationDbContext context;


        public StudentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }



        public IEnumerable<Student> GetStudents()
        {
            return context.Students.Include(s =>s.Department).ToList();
        }

        public Student GetStudentById(int studentId)
        {
            return  context.Students.Include(s => s.Department).SingleOrDefault(s => s.Id== studentId);
        }

       

        public void InsertStudent(Student student)
        {
            context.Students.Add(student);
        }

        public void DeleteStudent(int studentID)
        {
            Student student = context.Students.Find(studentID);
            context.Students.Remove(student);
        }

        public void UpdateStudent(Student student)
        {
            context.Entry(student).State = EntityState.Modified;
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