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
    public class LoginRepository: ILoginRepository
    {
        private readonly IDbContext _dbContext;

        public LoginRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Login> GetAllLogins()
        {
            IEnumerable<Login> result = _dbContext.Connection.Query<Login>(
                "LOGIN_PACKAGE.GetAllLogins", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Login GetLoginById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_login_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Login> result = _dbContext.Connection.Query<Login>(
                "LOGIN_PACKAGE.GetLoginById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateLogin(Login login)
        {
            var p = new DynamicParameters();
            p.Add("p_username", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_password", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_role_id", login.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_student_id", login.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("LOGIN_PACKAGE.CreateLogin", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateLogin(Login login)
        {
            var p = new DynamicParameters();
            p.Add("p_login_id", login.Loginid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_username", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_password", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_role_id", login.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_student_id", login.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("LOGIN_PACKAGE.UpdateLogin", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteLogin(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_login_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("LOGIN_PACKAGE.DeleteLogin", p, commandType: CommandType.StoredProcedure);
        }
    }
}