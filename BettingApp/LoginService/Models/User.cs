namespace LoginService.Models
{
    public class User
    {
        public Guid UserId { get; set; } = new Guid();
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}