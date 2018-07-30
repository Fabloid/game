using game.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace game.Models.Сlasses
{
    public class Game
    {
        [Key]
        public int _id { get; set; }
        public Winner _winner { get; set; }

        public Game() { }
        public Game(int winner)
        {
            _winner = (Winner)winner;
        }
    }
}