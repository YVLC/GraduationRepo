﻿namespace BettingApp.Models
{
    public class User
    {
        public Guid Id { get; set; } = new Guid();
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Password { get; set; } = string.Empty;
        public virtual List<Bets> Bets { get; set; } = new List<Bets>();
    }
}