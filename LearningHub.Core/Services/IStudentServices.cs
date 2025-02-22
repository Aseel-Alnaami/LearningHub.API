using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Services
{
    public interface IStudentServices
    {
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteAllStudents();
        List<string> GetAllStudentNames();
        List<Student> GetStudentByFirstName(string firstName);
        List<Student> GetStudentByBirthDate(DateTime birthDate);
        List<Student> GetStudentsByBirthDateInterval(DateTime startDate, DateTime endDate);
        List<string> GetStudentNames();
        List<Student> GetTopNStudentsByMarks(int n);

    }
}
