using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Repository
{
    public class StudentRepository: IStudentRepository
    {

        private readonly IDbContext _dbContext;

        public StudentRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Student> GetAllStudents()
        {
            IEnumerable<Student> result = _dbContext.Connection.Query<Student>(
                "Student_Package.GetAllStudent", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Student GetStudentById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_student_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Student> result = _dbContext.Connection.Query<Student>(
                "Student_Package.GetStudentById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateStudent(Student student)
        {
            var p = new DynamicParameters();
            p.Add("First_name", student.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Last_name", student.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("BD", student.Dateofbirth, dbType: DbType.Date, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Student_Package.CreateSTD", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateStudent(Student student)
        {
            var p = new DynamicParameters();
            p.Add("ID", student.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("First_name", student.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Last_name", student.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("BD", student.Dateofbirth, dbType: DbType.Date, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Student_Package.UpdateSTD", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteAllStudents()
        {
            _dbContext.Connection.Execute("Student_Package.DeleteAllStudents", commandType: CommandType.StoredProcedure);
        }

        public List<string> GetAllStudentNames()
        {
            IEnumerable<string> result = _dbContext.Connection.Query<string>(
                "Student_Package.GetAllStudentNames", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Student> GetStudentByFirstName(string firstName)
        {
            var p = new DynamicParameters();
            p.Add("First_name", firstName, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Student> result = _dbContext.Connection.Query<Student>(
                "Student_Package.GetStudentByFirstName", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Student> GetStudentByBirthDate(DateTime birthDate)
        {
            var p = new DynamicParameters();
            p.Add("BD", birthDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            IEnumerable<Student> result = _dbContext.Connection.Query<Student>(
                "Student_Package.GetStudentByBirthDate", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Student> GetStudentsByBirthDateInterval(DateTime startDate, DateTime endDate)
        {
            var p = new DynamicParameters();
            p.Add("StartDate", startDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("EndDate", endDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            IEnumerable<Student> result = _dbContext.Connection.Query<Student>(
                "Student_Package.GetStudentsByBirthDateInterval", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<string> GetStudentNames()
        {
            IEnumerable<string> result = _dbContext.Connection.Query<string>(
                "Student_Package.GetStudentNames", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Student> GetTopNStudentsByMarks(int n)
        {
            var p = new DynamicParameters();
            p.Add("n", n, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Student> result = _dbContext.Connection.Query<Student>(
                "Student_Package.GetTopNStudentsByMarks", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }

}
