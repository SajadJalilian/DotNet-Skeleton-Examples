using System.Collections.Generic;
using Consumer.Persistence.Models;

namespace Consumer.Persistence.Repository.Interfaces
{
    public interface IStudentRepo
    {
        List<StudentModel> GetStudents();
        StudentModel InsertStudent(string firstName, string lastName);
    }
}