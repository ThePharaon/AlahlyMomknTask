using AlahlyMomknTask.Models.Business;
using AlahlyMomknTask.Models.Request;
using AlahlyMomknTask.Server.Repositories;
using AlahlyMomknTask.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlahlyMomknTask.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;
        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> DoLogin(LoginData loginData)
        {
           return Ok(await _repository.DoLogin(loginData));
        }

        [HttpGet]
        [Route("CheckTokenValidation")]
        public IActionResult DoCheckTokenValidation()
        {
            return Ok();
        }
    }
}
