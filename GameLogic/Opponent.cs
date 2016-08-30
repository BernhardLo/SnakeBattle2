using GameLogic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeBattle2
{
    public class Opponent
    {

        public Color Color { get; set; }
        public bool IsAlive { get; set; }
        public string Name { get; set; }
        public int[] Position { get; set; }
        public Hex LastClicked { get; set; }
        public List<Hex> ValidMoves { get; set; }
        public bool IsFirstTurn { get; set; }

        public Opponent (string name, Color col)
        {
            Name = name;
            Color = col;
            IsAlive = true;
            Position = new int[2];
            ValidMoves = new List<Hex>();
            IsFirstTurn = true;
        }
    }
}
