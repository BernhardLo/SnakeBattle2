using GameLogic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class BoardState
    {
        private System.Drawing.Color backgroundColor;
        private System.Drawing.Color gridColor;
        private int gridPenWidth;
        private Hex activeHex;
        private System.Drawing.Color activeHexBorderColor;
        private int activeHexBorderWidth;


        #region Properties

        public System.Drawing.Color BackgroundColor
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

        public System.Drawing.Color GridColor
        {
            get
            {
                return gridColor;
            }
            set
            {
                gridColor = value;
            }
        }

        public int GridPenWidth
        {
            get
            {
                return gridPenWidth;
            }
            set
            {
                gridPenWidth = value;
            }
        }

        public Hex ActiveHex
        {
            get
            {
                return activeHex;
            }
            set
            {
                activeHex = value;
            }
        }

        public List<Hex> ActiveHexes { get; set; } //BL

        public System.Drawing.Color ActiveHexBorderColor
        {
            get
            {
                return activeHexBorderColor;
            }
            set
            {
                activeHexBorderColor = value;
            }
        }

        public int ActiveHexBorderWidth
        {
            get
            {
                return activeHexBorderWidth;
            }
            set
            {
                activeHexBorderWidth = value;
            }
        }

        public Color PlayerHighlightColor { get; set; }

        #endregion

        public BoardState()
        {
            backgroundColor = Color.Black;
            gridColor = Color.Black;
            gridPenWidth = 1;
            activeHex = null;
            activeHexBorderColor = Color.Blue;
            activeHexBorderWidth = 1;
            ActiveHexes = new List<Hex>();
        }
    }
}
