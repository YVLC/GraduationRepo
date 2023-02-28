using BettingApp.Models;

namespace BettingApp.Services.BetsService
{
    public interface IBetService
    {
        Task<List<Bets>> GetAllBetsByUser(Guid id);
        Task<bool> CreateBet(Bets bets);
    }
}
