using BettingApp.Data;
using BettingApp.Models;
using BettingApp.Services.BetsService;
using Microsoft.EntityFrameworkCore;

public class BetService : IBetService
{
    private readonly DataContext _context;

    public BetService(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateBet(Bets bets)
    {
       _context.Bets.Add(bets);
        return true;
    }

    public async Task<List<Bets>> GetAllBetsByUser(Guid id)
    {
        var bets = await _context.Bets.ToListAsync();
        List<Bets> result = new List<Bets>();
        foreach (var i in bets)
        {
            if (i.UserId == id)
            {
                result.Add(i);
            }
        }
        return result;
    }
}