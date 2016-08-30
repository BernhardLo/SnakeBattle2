using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    class OpponentNew : PlayerNew
    {
        public List<Hex> ValidMoves { get; set; }

        public OpponentNew(string name, Color color) : base (name, color)
        {
            ValidMoves = new List<Hex>();
        }

    }
}
