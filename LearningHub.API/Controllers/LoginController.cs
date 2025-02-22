using LearningHub.Core.Data;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILoginServices loginServices;
        public LoginController (ILoginServices loginServices)
        {
            this.loginServices = loginServices;
        }

        [HttpPost]
        public void CreateLogin(Login login)
        {
            loginServices.CreateLogin(login);
        }

        [HttpDelete]
        [Route("DeleteLogin/{id}")]
        public void DeleteLogin(int id)
        {
            loginServices.DeleteLogin(id);
        }

        [HttpGet]
        public List<Login> GetAllLogins()
        {
            return loginServices.GetAllLogins();
        }

        [HttpGet]
        [Route("GetLoginById/{id}")]
        public Login GetLoginById(int id)
        {
            return loginServices.GetLoginById(id);
        }

        [HttpPut]
        public void UpdateLogin(Login login)
        {
            loginServices.UpdateLogin(login);
        }
    }
}
