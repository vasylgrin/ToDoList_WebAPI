//using Microsoft.AspNetCore.Mvc;
//using ToDoList_WEB_Services.Services;

//namespace ToDoList_WEB_ASP.NET.CORE_React.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly UserService _userService;

//        public UserController()
//        {
//            _userService = new UserService();
//        }


//        [HttpPost, Route("SignIn")]
//        public async Task<IActionResult> SignIn([FromBody] LoginData loginData)
//        {
//            var user = await _userService.FindUserAsync(loginData.Login, loginData.Password);
//            if (user is null)
//            {
//                return NotFound("Login wasn't found.");
//            }

//            return Ok(user);
//        }

//        [HttpPost, Route("SignIn")]
//        public async Task<IActionResult> SignUp([FromBody] LoginData loginData)
//        {
//            var user = await _userService.FindUserAsync(loginData.Login, loginData.Password);
//            if (user is null)
//            {
//                return NotFound("Login wasn't found.");
//            }

//            return Ok(user);
//        }


//    }

//    public class LoginData
//    {
//        public string Login { get; set; }
//        public string Password { get; set; }
//    }

//    public class UserRegisterData
//    {
//        public string Name { get; set; }

//        public string Email { get; set; }
//    }
//}
