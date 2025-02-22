using LearningHub.Core.Data;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;


namespace LearningHub.API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IStudentServices studentServices;
        public StudentController(IStudentServices studentServices)
        {
            this.studentServices = studentServices;
        }

        [HttpPost]
        public void CreateStudent(Student student)
        {
            studentServices.CreateStudent(student);
        }

        [HttpDelete]
        [Microsoft.AspNetCore.Mvc.Route("DeleteAllStudents")]
        public void DeleteAllStudents()
        {
            studentServices.DeleteAllStudents();
        }

        [HttpGet]
        public List<string> GetAllStudentNames()
        {
            return studentServices.GetAllStudentNames();
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("GetAllStudents")]
        public List<Student> GetAllStudents()
        {
            return studentServices.GetAllStudents();
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("GetStudentByBirthDate/{birthDate}")]
        public List<Student> GetStudentByBirthDate(DateTime birthDate)
        {
            return studentServices.GetStudentByBirthDate(birthDate);
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("GetStudentByFirstName/{firstName}")]
        public List<Student> GetStudentByFirstName(string firstName)
        {
            return studentServices.GetStudentByFirstName(firstName);
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("GetStudentById/{id}")]
        public Student GetStudentById(int id)
        {
            return studentServices.GetStudentById(id);
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("GetStudentNames")]
        public List<string> GetStudentNames()
        {
            return studentServices.GetStudentNames();
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("GetStudentsByBirthDateInterval/{startDate}/{endDate}")]
        public List<Student> GetStudentsByBirthDateInterval(DateTime startDate, DateTime endDate)
        {
            return studentServices.GetStudentsByBirthDateInterval(startDate, endDate);
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("GetTopNStudentsByMarks/{n}")]
        public List<Student> GetTopNStudentsByMarks(int n)
        {
            return studentServices.GetTopNStudentsByMarks(n);
        }

        [HttpPut]
        public void UpdateStudent(Student student)
        {
            studentServices.UpdateStudent(student);
        }
    }
}
