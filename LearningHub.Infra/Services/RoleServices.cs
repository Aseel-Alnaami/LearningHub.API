using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using LearningHub.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Services
{
    public class RoleServices :IRoleServices
    { 
        private readonly IRoleRepository _roleRepository; //(inject from the repo) l7ta tegder tshof el cabel
        
        public RoleServices(IRoleRepository roleRepository) { 
        
            _roleRepository = roleRepository;
        }

        public void CreateRole(Role role)
        {
            _roleRepository.CreateRole(role);
        }

        public void DeleteRole(int id)
        {
            _roleRepository.DeleteRole(id);
        }

        public List<Role> GetAllRoles()
        {
           return _roleRepository.GetAllRoles();   
        }

        public Role GetRoleById(int id)
        {
             return _roleRepository.GetRoleById(id);
        }

        public void UpdateRole(Role role)
        {
            _roleRepository.UpdateRole(role);
        }
    }
}
