namespace BettingApp.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUser(int id);
        Task<bool> Register(User user);
        Task<List<User>> UpdateUser(User request);
        Task<List<User>> DeleteUser(int id);

    }
}
