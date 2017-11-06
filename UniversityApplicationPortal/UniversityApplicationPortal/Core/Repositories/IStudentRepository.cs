using System;
using System.Collections.Generic;
using UniversityApplicationPortal.Core.Models;

namespace UniversityApplicationPortal.Core.Repositories
{
    public  interface IStudentRepository : IDisposable
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentById(int studentId);
        void InsertStudent(Student student);
        void DeleteStudent(int studentId);
        void UpdateStudent(Student student);
        void Save();
    }
}
