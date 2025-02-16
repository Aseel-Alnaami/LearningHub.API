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

    public class RoleRepository : IRoleRepository
    {
        private readonly IDbContext _dbContext;

        public RoleRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Role> GetAllRoles()
        {
            IEnumerable<Role> result = _dbContext.Connection.Query<Role>(
                "ROLE_PACKAGE.GetAllRoles", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Role GetRoleById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_role_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Role> result = _dbContext.Connection.Query<Role>(
                "ROLE_PACKAGE.GetRoleById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateRole(Role role)
        {
            var p = new DynamicParameters();
            p.Add("p_role_name", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("ROLE_PACKAGE.CreateRole", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateRole(Role role)
        {
            var p = new DynamicParameters();
            p.Add("p_role_id", role.Idrol, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_role_name", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("ROLE_PACKAGE.UpdateRole", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteRole(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_role_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("ROLE_PACKAGE.DeleteRole", p, commandType: CommandType.StoredProcedure);
        }
    }
}
