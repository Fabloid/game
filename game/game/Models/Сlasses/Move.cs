using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using game.Models.Enums;

namespace game.Models.Сlasses
{
    public class Move
    {
        [Key]
        public int _id { get; set; }
        public int _game_id { get; set; }

        public Winner _winner { get; set; }        
        public int _number_cell { get; set; }

        public Move() { }
        public Move(int game_id, int person, int number_cell)
        {
            _game_id = game_id;
            _winner = (Winner)person;
            _number_cell = number_cell;
        }
    }
}