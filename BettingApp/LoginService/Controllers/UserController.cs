using LoginService.Data;
using LoginService.Models;
using LoginService.Requests;
using LoginService.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace LoginService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<User>>> Get()
        {
            List<User> temp = new List<User>();
            var users = await _userService.GetAllUsers();
            return users;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(Guid id)
        {
            return await _userService.GetUser(id);
        }
        [HttpPut("update")]
        public async Task<ActionResult<List<User>>> UpdateUser(UpdateRequest request)
        {
            return await _userService.UpdateUser(request);
        }

        [HttpPost("register")]
        public async Task<ActionResult<int>> AddUser(AuthRequest user)
        {
            return await _userService.Register(user);
        }
        [HttpPost("auth")]
        public async Task<ActionResult<string>> Authenticate(LoginRequest req)
        {
            var a = await _userService.Authenticate(req);
            if(a == null)
            {
                return BadRequest("Invalid username or password");
            }
            return Ok(a);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(Guid id)
        {
            return await _userService.DeleteUser(id);
        }
    }
}
