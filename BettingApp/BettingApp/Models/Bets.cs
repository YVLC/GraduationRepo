using Microsoft.EntityFrameworkCore;

namespace BettingApp.Models
{
    public class Bets
    {
        public Guid BetsId { get; set; } = new Guid();
        public string Name { get; set; } = string.Empty;
        public float Ammount { get; set; } = float.NaN;
        public float Win { get; set; } = float.NaN;
        public Guid UserId { get; set; } = new Guid();
        public int GameId { get; set; } = 0;
    }
}
