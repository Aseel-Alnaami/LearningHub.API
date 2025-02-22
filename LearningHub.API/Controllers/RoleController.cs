using LearningHub.Core.Data;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices roleServices;
        public RoleController(IRoleServices roleServices) { 
        this.roleServices = roleServices;
        }

        [HttpPost]
        public void CreateRole(Role role)
        {
            roleServices.CreateRole(role);
        }

        [HttpDelete]
        [Route("DeleteRole/{id}")]
        public void DeleteRole(int id)
        {
            roleServices.DeleteRole(id);
        }

        [HttpGet]
        public List<Role> GetAllRoles()
        {
            return roleServices.GetAllRoles();
        }

        [HttpGet]
        [Route("GetRoleById/{id}")]
        public Role GetRoleById(int id)
        {
            return roleServices.GetRoleById(id);
        }

        [HttpPut]
        public void UpdateRole(Role role)
        {
            roleServices.UpdateRole(role);
        }



    }
}
