using BettingApp;
using BettingApp.Data;
using BettingApp.Services.UserService;
using Microsoft.EntityFrameworkCore;

namespace Test.API.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> Register(User hero)
        {
            var user = await _context.Users.ToListAsync();
            foreach(var i in user)
            {
                if (i.UserName == hero.UserName)
                {
                    throw new Exception("Username Exists");
                }
            }
            _context.Users.Add(hero);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return null;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            var user2 = await _context.Users.ToListAsync();
            return user2;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return null;
            return user;
        }

        public async Task<List<User>> UpdateUser(User request)
        {
            var dbuser = await _context.Users.FindAsync(request.Id);
            if (dbuser == null)
                return null;

            dbuser.UserName = request.UserName;
            dbuser.Password = request.Password;
            dbuser.Email = request.Email;

            await _context.SaveChangesAsync();

            return await _context.Users.ToListAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Authenticate(string userName, string passWord)
        {
            var user = await _context.Users.ToListAsync();
            foreach (var i in user)
            {
                if (i.UserName == userName && i.Password == passWord)
                { 
                    return i;
                }
            }
            return null;
        }
    }
}
