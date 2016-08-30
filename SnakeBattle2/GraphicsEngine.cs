using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic;

namespace SnakeBattle2
{
    public class GraphicsEngine
    {
        private Board board;
        private Game _game;
        private float boardPixelWidth;
        private float boardPixelHeight;
        private int boardXOffset;
        private int boardYOffset;

        public GraphicsEngine(Board board)
        {
            this.Initialize(board, 0, 0);
        }

        public GraphicsEngine(Board board, int xOffset, int yOffset, Game game)
        {
            _game = game;
            this.Initialize(board, xOffset, yOffset);
        }

        public int BoardXOffset
        {
            get
            {
                return boardXOffset;
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public int BoardYOffset
        {
            get
            {
                return boardYOffset;
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        private void Initialize(Board board, int xOffset, int yOffset)
        {
            this.board = board;
            this.boardXOffset = xOffset;
            this.boardYOffset = yOffset;
        }

        public void Draw(Graphics graphics)
        {

            int width = Convert.ToInt32(System.Math.Ceiling(board.PixelWidth)) + 30;
            int height = Convert.ToInt32(System.Math.Ceiling(board.PixelHeight));
            // seems to be needed to avoid bottom and right from being chopped off
            width += 1;
            height += 1;

            //
            // Create drawing objects
            //
            Bitmap bitmap = new Bitmap(width, height);
            Graphics bitmapGraphics = Graphics.FromImage(bitmap);
            Pen blackPen = new Pen(Color.Black);
            Pen thickPen = new Pen(Color.Black);
            SolidBrush sb = new SolidBrush(Color.Black);


            //
            // Draw Board background
            //
            sb = new SolidBrush(board.BoardState.BackgroundColor);
            bitmapGraphics.FillRectangle(sb, 0, 0, width, height); //added 50 to x

            //
            // Draw Hex Background 
            //
            for (int i = 0; i < board.Hexes.GetLength(0); i++)
            {
                for (int j = 0; j < board.Hexes.GetLength(1); j++)
                {
                    if (board.hexes[j, i].IsValid)
                        bitmapGraphics.FillPolygon(new SolidBrush(_game._player.HighlightColor), board.Hexes[j, i].Points); // Draws highlight color
                    else
                        bitmapGraphics.FillPolygon(new SolidBrush(board.Hexes[j, i].HexState.BackgroundColor), board.Hexes[j, i].Points); // Draws standard hex color
                }
            }


            //
            // Draw Hex Grid
            //
            blackPen.Color = board.BoardState.GridColor;
            blackPen.Width = board.BoardState.GridPenWidth;

            for (int i = 0; i < board.Hexes.GetLength(0); i++)
            {
                for (int j = 0; j < board.Hexes.GetLength(1); j++)
                {
                    bitmapGraphics.DrawPolygon(blackPen, board.Hexes[j, i].Points); //changed order of i/j
                }
            }

            //
            // Draw Active Hex, if present
            //
            if (board.BoardState.ActiveHex != null)
            {
                blackPen.Color = board.BoardState.ActiveHexBorderColor;
                blackPen.Width = board.BoardState.ActiveHexBorderWidth;
                bitmapGraphics.DrawPolygon(blackPen, board.BoardState.ActiveHex.Points);
            }

            try
            {
                foreach (var item in board.BoardState.ActiveHexes)
                {
                    thickPen.Width = /*board.BoardState.ActiveHexBorderWidth;*/ 5;
                    bitmapGraphics.DrawPolygon(thickPen, item.Points);
                }
            } catch (Exception ex)
            {

            }



            //
            // Draw internal bitmap to screen
            //
            graphics.DrawImage(bitmap, new Point(this.boardXOffset, this.boardYOffset));

            //
            // Release objects
            //
            bitmapGraphics.Dispose();
            bitmap.Dispose();

        }

    }
}
