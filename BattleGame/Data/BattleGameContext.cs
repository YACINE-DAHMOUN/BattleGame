using BattleGame.Models;
using Microsoft.EntityFrameworkCore;

namespace BattleGame.Data
{
    public class BattleGameContext : DbContext
    {
        public BattleGameContext(DbContextOptions<BattleGameContext> options) 
            : base(options)
        {
        }

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}