using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }   

        [HttpPost("login")]     
        public IActionResult Login([FromBody]UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if(!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
           var result =  _authService.CreateAccessToken(userToLogin.Data);
           if(result.Success)
           {
               return Ok(result.Data);
           }
           return BadRequest(result.Message);


        }

        [HttpPost("register")]     
        public IActionResult Register([FromBody]UserForRegisterDto userForRegisterDto)
        {
            var userExits = _authService.UserExists(userForRegisterDto.Username,userForRegisterDto.Email);
            if(!userExits.Success)
            {
                return BadRequest(userExits.Message);
            }
            var registerResult = _authService.Register(userForRegisterDto);
            var result =  _authService.CreateAccessToken(registerResult.Data);

            if(result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);


        }
    }
}