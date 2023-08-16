using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList_WEB_Domain.DomainModels;
using ToDoList_WEB_Domain.Mappers;
using ToDoList_WEB_Services.Services;

namespace ToDoList_WEB_WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserService _userService;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
            _userService = new UserService(_configuration);
        }


        [HttpPost, Route("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] LoginDataDTO loginData)
        {
            var jwtTokenString = await _userService.FindUserAsync(loginData);
            if (jwtTokenString is null)
            {
                return Unauthorized("Login or password wasn't found.");
            }

            return Ok(jwtTokenString);
        }


        [HttpGet, Route("LoadToDoes/{login}")]
        public IActionResult LoadToDoes(string login)
        {
            var toDoes = _userService.LoadUsersToDoes(login);
            if (toDoes is null)
            {
                return BadRequest("Login wasn't found.");
            }

            return Ok(toDoes);
        }


        [HttpPost, Route("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] UserDTO userDM)
        {
            var user = await _userService.AddNewUserAsync(userDM);
            return Ok(user);
        }
    }
}
