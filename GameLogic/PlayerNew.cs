using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    class PlayerNew
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Color HighlightColor { get; set; }
        public Hex LastClicked { get; set; }
        public int[] Position { get; set; }
        public bool IsAlive { get; set; }
        public bool MyTurn { get; set; }

        public PlayerNew(string Name, Color color)
        {
            if (color == Color.Red)
                HighlightColor = Color.LightSalmon;
            if (color == Color.Blue)
                HighlightColor = Color.LightSteelBlue;
            if (color == Color.Yellow)
                HighlightColor = Color.Wheat;
            if (color == Color.Green)
                HighlightColor = Color.LightGreen;
            if (color == Color.Gray)
                HighlightColor = Color.Lavender;
            if (color == Color.HotPink)
                HighlightColor = Color.Pink;
            if (color == Color.Orange)
                HighlightColor = Color.Wheat;
            if (color == Color.Purple)
                HighlightColor = Color.Plum;
        }
    }
}
