using BettingApp.Models;
using BettingApp.Requests;

namespace BettingApp.Services.BetsService
{
    public interface IBetService
    {
        Task<List<Bets>> GetAllBetsByUser(int id);
        Task<bool> CreateBet(Bets bets);
    }
}
