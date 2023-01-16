using System;
using Microsoft.AspNetCore.Mvc;
using userWebApi.Services;

namespace userWebApi.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{username}")]
        public ActionResult GetUser(string username)
        {
            var user = _userService.GetByUsername(username);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create(User model)
        {
            _userService.Create(model);
            return Ok(new { message = "User created" });
        }

        [HttpPut("{username}")]
        public IActionResult Update(string username, UpdateUserModel model)
        {
            _userService.Update(username, model);
            return Ok(new { message = "User updated" });
        }

        [HttpDelete("{username}")]
        public IActionResult DeleteUser(string username)
        {
            _userService.Delete(username);
            return Ok(new { message = "User deleted" });
        }
    }
}
