using Microsoft.AspNetCore.Mvc;
using StorageWebApi.Data.DTO;
using StorageWebApi.Services;

namespace StorageWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userservice;
        public UserController(IUserService userservice)
        {
            _userservice = userservice;
        }
        [HttpPost]
        public ActionResult RegistrationUser(RegistrationUserDto dto)
        {
            var result = _userservice.Registration(dto);
            if (result == false)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPut]
        public ActionResult LoginUser(LoginUserDto dto)
        {
            var result = _userservice.Login(dto);
            if (result == false)
            {
                return BadRequest();
            }
            return Ok();
        }
    }

}
