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
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Bets>> GetAllBetsByUser()
    {
        var bets = await _context.Bets.ToListAsync();
        return bets;
    }
}