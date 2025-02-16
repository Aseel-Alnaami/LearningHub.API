using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using LearningHub.Infra.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LearningHub.Infra.Repository
{
    public class CourseRepository: ICourseRepository
    {
        private readonly IDbContext _dbContext;

        public CourseRepository(IDbContext dbContext) {

           _dbContext = dbContext;
        }


        public List<Course> GetAllCourses() {
            //we have to apen the connection , and if we use the select we should to use query.
            IEnumerable<Course> result = _dbContext.Connection.Query<Course>
                ("Course_Package.GetAllCourses",commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Course GetCourseById(int id)
        { 
            // L7ta adman ino ma ycon fe error bel parameters...
            var p=new DynamicParameters();

            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Course> result = _dbContext.Connection.Query<Course>
               ("Course_Package.GetCourseById", p,commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
        public void CreateCourse(Course course) {
            var p = new DynamicParameters();
            p.Add("course_name",course.Coursename,dbType:DbType.String,direction:ParameterDirection.Input);
            p.Add("catId",course.Categoryid,dbType:DbType.Int32,direction:ParameterDirection.Input);
            p.Add("image",course.Imagename,dbType:DbType.String,direction:ParameterDirection.Input);
            p.Add("start_Date",course.Startdate,dbType:DbType.DateTime,direction:ParameterDirection.Input);
            p.Add("end_Date",course.Enddate,dbType:DbType.DateTime, direction:ParameterDirection.Input);
            p.Add("price",course.Price,dbType:DbType.Int32,direction: ParameterDirection.Input);


            var result = _dbContext.Connection.Execute
              ("Course_Package.CreateCourse", p, commandType: CommandType.StoredProcedure);

        }

        public void UpdateCourse(Course course) {
            var p = new DynamicParameters();
            p.Add("course_name", course.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("catId", course.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("image", course.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("start_Date", course.Startdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("end_Date", course.Enddate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("price", course.Price, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = _dbContext.Connection.Execute
              ("Course_Package.UpdateCourse", p, commandType: CommandType.StoredProcedure);

        }


        public void DeleteCourse(int id) {

            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute
              ("Course_Package.DeleteCourse",p, commandType: CommandType.StoredProcedure);
      
        }



    }
}
