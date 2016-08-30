using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeBattle2
{
    public class HexState
    {
        private Color backgroundColor;
        public Color BackgroundColor
        {
            get
            {
                return backgroundColor;
            }
            set
            {
                backgroundColor = value;
            }
        }


        public HexState()
        {
            this.backgroundColor = Color.WhiteSmoke;
        }

    }
}
