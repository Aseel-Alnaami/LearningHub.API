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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContext _dbContext;

        public CategoryRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Category> GetAllCategories()
        {
            IEnumerable<Category> result = _dbContext.Connection.Query<Category>(
                "CATEGORY_PACKAGE.GetAllCategories", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Category GetCategoryById(int id)
        {
            var p = new DynamicParameters();
            p.Add("catid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Category> result = _dbContext.Connection.Query<Category>(
                "CATEGORY_PACKAGE.GetCategoryById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateCategory(Category category)
        {
            var p = new DynamicParameters();
            p.Add("catname", category.CategoryName, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("CATEGORY_PACKAGE.CreateCategory", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateCategory(Category category)
        {
            var p = new DynamicParameters();
            p.Add("catid", category.Idcat, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("catname", category.CategoryName, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("CATEGORY_PACKAGE.UpdateCategory", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCategory(int id)
        {
            var p = new DynamicParameters();
            p.Add("catid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("CATEGORY_PACKAGE.DeleteCategory", p, commandType: CommandType.StoredProcedure);
        }
    }
}