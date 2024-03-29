﻿using BettingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BettingApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Bets> Bets { get; set; }
    }
}
