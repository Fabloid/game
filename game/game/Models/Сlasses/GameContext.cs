using System.Data.Entity;

namespace game.Models.Сlasses
{
    public class GameContext: DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Move> Moves { get; set; }
    }
}