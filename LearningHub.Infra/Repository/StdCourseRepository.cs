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
    public class StdCourseRepository : IStdCourseRepository
    {
        private readonly IDbContext _dbContext;

        public StdCourseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateStdCourse(Stdcourse stdCourse)
        {
            var p = new DynamicParameters();
            p.Add("Studentid", stdCourse.Stid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Corid", stdCourse.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Markstd", stdCourse.Markofstd, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Dateregister", stdCourse.Dateofregister, dbType: DbType.Date, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("stdcourse_Package.CreateStdCourse", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteStdCourse(int id)
        {
            var p = new DynamicParameters();
            p.Add("DID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("stdcourse_Package.DeleteStdCourse", p, commandType: CommandType.StoredProcedure);
        }

        public List<Stdcourse> GetAllStdCourses()
        {
            IEnumerable<Stdcourse> result = _dbContext.Connection.Query<Stdcourse>(
                                        "stdcourse_Package.GitAllStdCourse", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Stdcourse GetStdCourseById(int id)
        {
            var p = new DynamicParameters();
            p.Add("CID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Stdcourse> result = _dbContext.Connection.Query<Stdcourse>(
                "stdcourse_Package.GetStdCourseById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateStdCourse(Stdcourse stdCourse)
        {
            var p = new DynamicParameters();
            p.Add("UID", stdCourse.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Studentid", stdCourse.Stid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Corid", stdCourse.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Markstd", stdCourse.Markofstd, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Dateregister", stdCourse.Dateofregister, dbType: DbType.Date, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("stdcourse_Package.UpdateStdCourse", p, commandType: CommandType.StoredProcedure);
        }
    }
}
