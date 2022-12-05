using Microsoft.EntityFrameworkCore;

namespace BettingApp.Models
{
    public class Bets
    {
        public Guid BetId { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Ammount { get; set; } = float.NaN;
        public float Win { get; set; } = float.NaN;
        public int UserId { get; set; } = int.MaxValue;
        public int GameId { get; set; } = 0;
        public int Id { get; set; }
        public virtual User User { get; set; }
    }
}
