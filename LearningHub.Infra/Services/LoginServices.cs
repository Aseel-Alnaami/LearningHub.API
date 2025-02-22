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
    public class LoginServices:ILoginServices
    {
        private readonly ILoginRepository _loginRepository;
        public LoginServices(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public void CreateLogin(Login login)
        {
            _loginRepository.CreateLogin(login);
        }

        public void DeleteLogin(int id)
        {
            _loginRepository.DeleteLogin(id);
        }

        public List<Login> GetAllLogins()
        {
           return _loginRepository.GetAllLogins();
        }

        public Login GetLoginById(int id)
        {
          return  _loginRepository.GetLoginById(id);
        }

        public void UpdateLogin(Login login)
        {
            _loginRepository.UpdateLogin(login);
        }
    }
}
