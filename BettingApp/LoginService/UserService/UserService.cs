using LoginService.Data;
using LoginService.Models;
using LoginService.Requests;
using LoginService.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace LoginService.UserService
{

    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public UserService(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<int> Register(AuthRequest request)
        {
            var users = await _context.Users.ToListAsync();
            foreach (var i in users)
            {
                if (i.UserName == request.UserName)
                {
                    throw new Exception(StatusCodes.Status409Conflict.ToString());
                }
            }
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            User user = new User
            {
                UserId = new Guid(),
                UserName = request.UserName,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<List<User>> DeleteUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return null;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            var user2 = await _context.Users.ToListAsync();
            return user2;
        }

        public async Task<User> GetUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return null;
            return user;
        }

        public async Task<List<User>> UpdateUser(UpdateRequest request)
        {
            var dbuser = await _context.Users.FindAsync(request.Id);
            if (dbuser == null)
                return null;
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            dbuser.UserName = request.UserName;
            dbuser.PasswordHash = passwordHash;
            dbuser.PasswordSalt = passwordSalt;
            dbuser.Email = request.Email;

            await _context.SaveChangesAsync();

            return await _context.Users.ToListAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<string> Authenticate(LoginRequest req)
        {
            var user = await _context.Users.ToListAsync();
            foreach (var i in user)
            {
                if (i.UserName == req.UserName && VerifyPasswordHash(req.Password, i.PasswordHash, i.PasswordSalt))
                {
                    string token = CreateToken(i);
                    return token;
                }
            }
            return null;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        private string CreateToken(User u)
        {
            List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, u.UserName)
        };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}