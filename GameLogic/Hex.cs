﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Hex
    {
        private System.Drawing.PointF[] points;
        private float side;
        private float h;
        private float r;
        private HexOrientation orientation;
        private float x;
        private float y;
        private HexState hexState;
        public int xCoord { get; set; } //BL
        public int yCoord { get; set; } //BL
        public bool IsValid { get; set; } //BL
        public bool OpponentValid { get; set; } //BL

        public int PossibleMoves { get; set; }

        /// <param name="side">length of one side of the hexagon</param>

        public Hex(float x, float y, float side, HexOrientation orientation)
        {
            Initialize(x, y, side, orientation);
        }

        public Hex(PointF point, float side, HexOrientation orientation)
        {
            Initialize(point.X, point.Y, side, orientation);
        }

        public Hex(float x, float y, float side, HexOrientation orientation, int xCoord, int yCoord) //BL
        {
            Initialize(x, y, side, orientation, xCoord, yCoord);
        }

        public Hex(PointF point, float side, HexOrientation orientation, int xCoord, int yCoord) //BL
        {
            Initialize(point.X, point.Y, side, orientation, xCoord, yCoord);
        }

        public Hex()
        { }

        /// <summary>
        /// Sets internal fields and calls CalculateVertices()
        /// </summary>
        private void Initialize(float x, float y, float side, HexOrientation orientation)
        {
            this.x = x;
            this.y = y;
            this.side = side;
            this.orientation = orientation;
            this.hexState = new HexState();
            CalculateVertices();
        }

        private void Initialize(float x, float y, float side, HexOrientation orientation, int xCoord, int yCoord) //BL
        {
            this.x = x;
            this.y = y;
            this.side = side;
            this.orientation = orientation;
            this.hexState = new HexState();
            CalculateVertices();
            this.xCoord = xCoord;
            this.yCoord = yCoord;
        }

        /// <summary>
        /// Calculates the vertices of the hex based on orientation. Assumes that points[0] contains a value.
        /// </summary>
        private void CalculateVertices()
        {
            //  
            //  h = short length (outside)
            //  r = long length (outside)
            //  side = length of a side of the hexagon, all 6 are equal length
            //
            //  h = sin (30 degrees) x side
            //  r = cos (30 degrees) x side
            //
            //		 h
            //	     ---
            //   ----     |r
            //  /    \    |          
            // /      \   |
            // \      /
            //  \____/
            //
            // Flat orientation (scale is off)
            //
            //     /\
            //    /  \
            //   /    \
            //   |    |
            //   |    |
            //   |    |
            //   \    /
            //    \  /
            //     \/
            // Pointy orientation (scale is off)

            h = MathClass.CalculateH(side);
            r = MathClass.CalculateR(side);

            switch (orientation)
            {
                case HexOrientation.Flat:
                    // x,y coordinates are top left point
                    points = new System.Drawing.PointF[6];
                    points[0] = new PointF(x, y);
                    points[1] = new PointF(x + side, y);
                    points[2] = new PointF(x + side + h, y + r);
                    points[3] = new PointF(x + side, y + r + r);
                    points[4] = new PointF(x, y + r + r);
                    points[5] = new PointF(x - h, y + r);
                    break;
                case HexOrientation.Pointy:
                    //x,y coordinates are top center point
                    points = new System.Drawing.PointF[6];
                    points[0] = new PointF(x, y);
                    points[1] = new PointF(x + r, y + h);
                    points[2] = new PointF(x + r, y + side + h);
                    points[3] = new PointF(x, y + side + h + h);
                    points[4] = new PointF(x - r, y + side + h);
                    points[5] = new PointF(x - r, y + h);
                    break;
                default:
                    throw new Exception("No HexOrientation defined for Hex object.");

            }

        }

        public HexOrientation Orientation
        {
            get
            {
                return orientation;
            }
            set
            {
                orientation = value;
            }
        }

        public System.Drawing.PointF[] Points
        {
            get
            {
                return points;
            }
            set
            {
            }
        }

        public float Side
        {
            get
            {
                return side;
            }
            set
            {
            }
        }

        public float H
        {
            get
            {
                return h;
            }
            set
            {
            }
        }

        public float R
        {
            get
            {
                return r;
            }
            set
            {
            }
        }

        public HexState HexState
        {
            get
            {
                return hexState;
            }
            set
            {
                
            }
        }

    }
}
