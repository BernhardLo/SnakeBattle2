using GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeBattle2
{
    public class MPGame
    {
        public MPGame(Player player, string host)
        {
            Player = player;
            Host = host;
        }

        public Player Player { get; set; }
        public string Host { get; set; }
    }
}
