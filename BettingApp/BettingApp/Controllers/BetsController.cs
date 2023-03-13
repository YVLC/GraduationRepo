using BettingApp.Models;
using BettingApp.Services.BetsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BettingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetsController : ControllerBase
        {
            private readonly IBetService _betService;

            public BetsController(IBetService betService)
            {
                _betService = betService;
            }

            [HttpGet("get-all")]
            public async Task<ActionResult<List<Bets>>> Get()
            {
                return await _betService.GetAllBetsByUser();
            }
            [HttpPost("create")]
            public async Task<ActionResult<bool>> Get(Bets bet)
            {
                return await _betService.CreateBet(bet);
            }
    }
    }
