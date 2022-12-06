using BettingApp.Models;
using BettingApp.Requests;

namespace BettingApp.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUser(Guid id);
        Task<int> Register(AuthRequest user);
        Task<List<User>> UpdateUser(User request);
        Task<List<User>> DeleteUser(Guid id);
        Task<string> Authenticate(LoginRequest req);
    }
}
