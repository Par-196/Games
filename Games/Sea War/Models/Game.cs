using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_War.Models
{
    public class Game
    {
        private Player Player { get; set; }
        private Bot Bot { get; set; }


        public Game(Player player, Bot bot)
        {
            Player = player;
            Bot = bot;
        }
    }
}
