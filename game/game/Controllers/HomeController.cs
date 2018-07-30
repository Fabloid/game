using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using game.Models.Сlasses;
using System.Data.Entity;

namespace game.Controllers
{
    public class HomeController : Controller
    {
        private GameContext db = new GameContext();
        Data data = new Data();
        PC pc = new PC();

        [HttpGet]
        public ActionResult Index(int id=0)
        {
            char[] s = new char[9] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
            bool is_end;
            if (id!=0)
            {
                is_end = (bool)Session["end"];
                if (!is_end)
                {
                    s = (char[])Session["press"];
                    if (s[id - 1] == ' ')
                    {
                        data.Add_move(id, 1);
                        s[id - 1] = 'X';

                        s = pc.Move_PC(s);
                        ViewBag.Result = pc.Result_game(s);
                        if (ViewBag.Result != " ")
                        {
                            Session["end"] = true;
                            int win = 0;
                            if (ViewBag.Result == "Вы победили") win = 1;
                            if (ViewBag.Result == "Победил ИИ") win = 2;
                            if (ViewBag.Result == "Ничья") win = 3;
                            data.Save_result_game(win);
                        }
                    }
                        ViewBag.Symbol1 = s[0];
                        ViewBag.Symbol2 = s[1];
                        ViewBag.Symbol3 = s[2];
                        ViewBag.Symbol4 = s[3];
                        ViewBag.Symbol5 = s[4];
                        ViewBag.Symbol6 = s[5];
                        ViewBag.Symbol7 = s[6];
                        ViewBag.Symbol8 = s[7];
                        ViewBag.Symbol9 = s[8];
                        Session["press"] = s;
                }
            }
            else
            {
                data.Add_game();
                Session["press"] = s;
                Session["end"] = false;
            }
            return View();
        }

        public ActionResult Info()
        {
            IEnumerable<Game> games = db.Games;
            ViewBag.Games = games;
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            IEnumerable<Move> moves = db.Moves;            
            ViewBag.query = moves.Where(m => m._game_id == id);
            ViewBag.game_id = id;
            return View();
        }
    }
}