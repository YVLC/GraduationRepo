using LoginService.Models;
using LoginService.Requests;

namespace LoginService.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUser(Guid id);
        Task<int> Register(AuthRequest user);
        Task<List<User>> UpdateUser(UpdateRequest request);
        Task<List<User>> DeleteUser(Guid id);
        Task<string> Authenticate(LoginRequest req);
    }
}
