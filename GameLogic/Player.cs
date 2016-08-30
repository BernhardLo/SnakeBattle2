using SnakeBattle2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Player
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Color HighlightColor { get; set; }
        public Hex LastClicked { get; set; }
        public Hex Position { get; set; }
        public bool IsAlive { get; set; }
        public bool IsFirstTurn { get; set; }
        public bool MyTurn { get; set; }

        public Player(string name, Color color)
        {
            Name = name;
            Color = color;

            if (color == Color.Red)
                HighlightColor = Color.LightSalmon;
            if (color == Color.Blue)
                HighlightColor = Color.LightSteelBlue;
            if (color == Color.Yellow)
                HighlightColor = Color.SandyBrown;
            if (color == Color.Green)
                HighlightColor = Color.LightGreen;
            if (color == Color.Gray)
                HighlightColor = Color.Silver;
            if (color == Color.HotPink)
                HighlightColor = Color.Pink;
            if (color == Color.DarkOrange)
                HighlightColor = Color.SandyBrown;
            if (color == Color.Purple)
                HighlightColor = Color.Plum;

        }

        public Player (string name)
        {
            // todo implement simple constructor
        }
    }
}
