using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using LearningHub.Core.Services;
using LearningHub.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository _studentRepository;

        public StudentServices(IStudentRepository studentRepository) {
            _studentRepository=studentRepository;
        }

        public void CreateStudent(Student student)
        {
            _studentRepository.CreateStudent(student);
        }

        public void DeleteAllStudents()
        {
            _studentRepository.DeleteAllStudents();
        }

        public List<string> GetAllStudentNames()
        {
           return _studentRepository.GetAllStudentNames();
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }

        public List<Student> GetStudentByBirthDate(DateTime birthDate)
        {
            return _studentRepository.GetStudentByBirthDate(birthDate);        }

        public List<Student> GetStudentByFirstName(string firstName)
        {
            return _studentRepository.GetStudentByFirstName(firstName);        }

        public Student GetStudentById(int id)
        {
            return _studentRepository.GetStudentById(id);
        }

        public List<string> GetStudentNames()
        {
            return _studentRepository.GetStudentNames();   
        }

        public List<Student> GetStudentsByBirthDateInterval(DateTime startDate, DateTime endDate)
        {
            return _studentRepository.GetStudentsByBirthDateInterval(startDate, endDate);
        }

        public List<Student> GetTopNStudentsByMarks(int n)
        {
            return _studentRepository.GetTopNStudentsByMarks(n);
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.UpdateStudent(student);    
        }
    }
}
