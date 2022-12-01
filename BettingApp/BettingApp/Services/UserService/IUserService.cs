using BettingApp.Requests;

namespace BettingApp.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUser(int id);
        Task<int> Register(User user);
        Task<List<User>> UpdateUser(User request);
        Task<List<User>> DeleteUser(int id);
        Task<int> Authenticate(LoginRequest req);
    }
}
