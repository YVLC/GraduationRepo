using BettingApp.Models;

namespace BettingApp.Services.BetsService
{
    public interface IBetService
    {
        Task<List<Bets>> GetAllBetsByUser();
        Task<bool> CreateBet(Bets bets);
    }
}
