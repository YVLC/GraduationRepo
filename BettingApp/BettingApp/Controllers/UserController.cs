using BettingApp.Data;
using BettingApp.Models;
using BettingApp.Requests;
using BettingApp.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BettingApp.Controllers
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
            return await _userService.GetAllUsers();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(Guid id)
        {
            return await _userService.GetUser(id);
        }
        [HttpPut("update")]
        public async Task<ActionResult<List<User>>> UpdateUser(User request)
        {
            return await _userService.UpdateUser(request);
        }

        [HttpPost("register")]
        public async Task<ActionResult<int>> AddUser(AuthRequest user)
        {
            return await _userService.Register(user);
        }
        [HttpPost("auth")]
        public async Task<ActionResult<int>> Authenticate(LoginRequest req)
        {
            var a = await _userService.Authenticate(req);
            if(a == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(Guid id)
        {
            return await _userService.DeleteUser(id);
        }
    }
}
