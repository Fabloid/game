using System.Linq;
using System.Data.Entity;
using game.Models.Enums;

namespace game.Models.Сlasses
{
    public class Data
    {
        private GameContext _db = new GameContext();
        private Game _game = new Game(0);

        public void Add_game()
        {
            _db.Games.Add(_game);
            _db.SaveChanges();
        }

        public void Save_result_game(int win_user)
        {
            _db.Games.Load();
            int count = _db.Games.Local.Count();
            Game game = _db.Games.Find(count);
            game._winner = (Winner)win_user;
            _db.SaveChanges();
        }

        public void Add_move(int cell, int person)
        {
            _db.Games.Load();
            int count = _db.Games.Local.Count();
            Move move = new Move(count, person, cell);
            _db.Moves.Add(move);
            _db.SaveChanges();
        }
    }
}