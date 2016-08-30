using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeBattle2
{
    public enum PointyVertice
    {
        Top = 0,
        UpperRight = 1,
        BottomRight = 2,
        Bottom = 3,
        BottomLeft = 4,
        TopLeft = 5,
    }

    public enum FlatVertice
    {
        UpperLeft = 0,
        UpperRight = 1,
        MiddleRight = 2,
        BottomRight = 3,
        BottomLeft = 4,
        MiddleLeft = 5,
    }

    public enum HexOrientation
    {
        /// <summary>
        /// Hex positioned with flat top and bottom
        /// </summary>
        Flat = 0,
        /// <summary>
        /// Hex positioned with points at top and botom
        /// </summary>
        Pointy = 1,
    }
}
