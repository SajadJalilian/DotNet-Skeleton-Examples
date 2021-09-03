using System.Collections.Generic;
using System.Linq;
using Consumer.Persistence.Models;
using Consumer.Persistence.Repository.Interfaces;

namespace Consumer.Persistence.Repository
{
    public class StudentRepo : IStudentRepo
    {
        public StudentRepo()
        {
            _students.Add(new StudentModel()
                { Id = 1, FirstName = "John", LastName = "Doe", BirthYear = 1990, StudentId = 1001 });
            _students.Add(new StudentModel()
                { Id = 1, FirstName = "Amanda", LastName = "Smith", BirthYear = 1991, StudentId = 1002 });
        }

        private List<StudentModel> _students = new List<StudentModel>();

        public List<StudentModel> GetStudents()
        {
            return _students;
        }

        public StudentModel InsertStudent(string firstName, string lastName)
        {
            StudentModel s = new StudentModel()
            {
                FirstName = firstName,
                LastName = lastName
            };
            s.Id = _students.Max(x => x.Id) + 1;
            _students.Add(s);
            return s;
        }
    }
}