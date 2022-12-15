using BettingApp.Data;
using BettingApp.Models;
using BettingApp.Requests;
using BettingApp.Services.BetsService;
using BettingApp.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace BettingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IBetService _betService;

        public UserController(IUserService userService, IBetService betService)
        {
            _userService = userService;
            _betService = betService;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<User>>> Get()
        {
            List<User> temp = new List<User>();
            var users = await _userService.GetAllUsers();
            foreach(var user in users)
            {
                var b = await _betService.GetAllBetsByUser(user.UserId);
                foreach (var item in b)
                {
                    user.Bets.Add(item);
                }
                temp.Add(user);
            }
            return temp;
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
