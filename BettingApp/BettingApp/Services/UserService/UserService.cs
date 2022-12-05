﻿using BettingApp.Data;
using BettingApp.Models;
using BettingApp.Requests;
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
        public async Task<int> Register(AuthRequest request)
        {
            var users = await _context.Users.ToListAsync();
            foreach(var i in users)
            {
                if (i.UserName == request.UserName)
                {
                    throw new Exception(StatusCodes.Status409Conflict.ToString());
                }
            }
            User user = new User {
                Id = new Guid(),
                UserName = request.UserName, 
                Email=request.Email, 
                Password=request.Password};

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

        public async Task<int> Authenticate(LoginRequest req)
        {
            var user = await _context.Users.ToListAsync();
            foreach (var i in user)
            {
                if (i.UserName == req.UserName && i.Password == req.Password)
                { 
                    return 1;
                }
            }
            return 0;
        }
    }
}
