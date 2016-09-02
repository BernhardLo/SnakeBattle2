using GameLogic;
using MessagesLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeBattle2
{
    public class SPGame
    {
        public Board _board;
        int _numberOfPlayers;
        public Player _player;
        private Color[] _availableColors;
        private List<Opponent> _opponents;
        private int _movesLeft = 2;
        SnakeBattle2 _windowRef;
        Thread AiPlacer;
        Thread AiMover;
        Thread _showWin;
        Random rnd = new Random();
        bool _gameOn;
        bool _playerLost;
        bool isMultiPlayer;
        bool mpStartingTurn;
        public bool mpStillmyturn;

        public SPGame(Board board, int numberOfPlayers, Player player, Color[] availableColors, SnakeBattle2 windowRef, bool isMultiPlayer)
        {
            _windowRef = windowRef;
            _movesLeft = 2;
            _board = board;
            _numberOfPlayers = numberOfPlayers;
            _player = player;
            _availableColors = availableColors;
            _gameOn = true;
            mpStillmyturn = true;
            _playerLost = false;
            this.isMultiPlayer = isMultiPlayer;
            if (!isMultiPlayer)
            {
                _player.MyTurn = true;
                _player.IsFirstTurn = true;
                _opponents = new List<Opponent>();
                CreateOpponents();
                //enable all hexes except edges as valid moves for current player
                EnableStartLocations();
            }
            else
            {
                mpStartingTurn = true;
            }

        }

        public void EnableStartLocations()
        {
            for (int x = 1; x < _board.Width - 1; x++)
                for (int y = 1; y < _board.Height - 1; y++)
                {
                    _board.hexes[x, y].IsValid = true;
                }
        }

        public void EnableStartLocationsMP()
        {
            for (int x = 1; x < _board.Width - 1; x++)
                for (int y = 1; y < _board.Height - 1; y++)
                {
                    _board.hexes[x, y].IsValid = true;
                }

            for (int x = 1; x < _board.Width - 1; x++)
                for (int y = 1; y < _board.Height - 1; y++)
                {
                    if (_board.hexes[x, y].HexState.BackgroundColor != Color.WhiteSmoke)
                    {
                        _board.hexes[x, y].IsValid = false;
                    }
                }

        }

        #region Basic Methods
        private void ClearValidMoves()
        {
            for (int x = 0; x < _board.Width; x++)
                for (int y = 0; y < _board.Height; y++)
                {
                    _board.hexes[x, y].IsValid = false;
                }
        }
        private void ClearValidOpponentMoves()
        {
            for (int x = 0; x < _board.Width; x++)
                for (int y = 0; y < _board.Height; y++)
                {
                    _board.hexes[x, y].OpponentValid = false;
                }
        }

        private void CreateOpponents()
        {
            List<Color> col = new List<Color>(_availableColors);
            int idx = col.IndexOf(_player.Color);
            col.RemoveAt(idx);
            Color[] tmpColors = col.ToArray();

            string[] tmpNames = { "Wall-E", "HAL 9000", "SkyNet", "AlphaGo", "Deep Blue", "GLaDOS", "T-1000",
                                  "R2-D2" , "C-3PO", "Ava", "Bender", "Baymax", "Bastion", "Optimus Prime",
                                  "Tay", "MechaGodzilla", "Agent Smith", "Tron", "Borg Queen", "Sir Killalot",
                                  "TARS", "Data", "RoboCop", "Roy Batty", "The Iron Giant", "Siri"};


            tmpColors = col.OrderBy(x => rnd.Next()).ToArray();
            string[] tmpNamesRnd = tmpNames.OrderBy(x => rnd.Next()).ToArray();

            for (int i = 0; i < _numberOfPlayers - 1; i++)
            {
                _opponents.Add(new Opponent(tmpNamesRnd[i], tmpColors[i]));
            }

            _windowRef.ShowOpponentIconsAndLabels(_opponents);
        }
        #endregion

        #region Movement Logic Player

        public void UpdateValidMovesFirstTurn(Hex hex)
        {

            if (hex.yCoord % 2 == 0) //even row
            {
                _board.hexes[hex.xCoord, hex.yCoord - 1].IsValid = true; //top right
                _board.hexes[hex.xCoord + 1, hex.yCoord].IsValid = true; //right
                _board.hexes[hex.xCoord, hex.yCoord + 1].IsValid = true; //bottom right
                _board.hexes[hex.xCoord - 1, hex.yCoord + 1].IsValid = true; //bottom left
                _board.hexes[hex.xCoord - 1, hex.yCoord].IsValid = true; //left
                _board.hexes[hex.xCoord - 1, hex.yCoord - 1].IsValid = true; //top left

            }
            else if (hex.yCoord % 2 == 1)//odd row
            {
                _board.hexes[hex.xCoord + 1, hex.yCoord - 1].IsValid = true; //top right
                _board.hexes[hex.xCoord + 1, hex.yCoord].IsValid = true; //right
                _board.hexes[hex.xCoord + 1, hex.yCoord + 1].IsValid = true; //bottom right
                _board.hexes[hex.xCoord, hex.yCoord + 1].IsValid = true; //bottom left
                _board.hexes[hex.xCoord - 1, hex.yCoord].IsValid = true; //left
                _board.hexes[hex.xCoord, hex.yCoord - 1].IsValid = true; //top left
            }

            _player.LastClicked = hex;
        }

        private void UpdateValidMoves(Hex hex)
        {
            Hex last = _player.LastClicked;

            //todo check for out of bounds
            if (_player.LastClicked.yCoord % 2 == 0) // even row
            {
                if (hex.xCoord == last.xCoord && hex.yCoord == last.yCoord - 1) //clicked to the top right of the previous
                    EvenRowTopRight(hex);

                else if (hex.xCoord == last.xCoord + 1 && hex.yCoord == last.yCoord) //clicked to the right of the previous 
                    EvenRowRight(hex);

                else if (hex.xCoord == last.xCoord && hex.yCoord == last.yCoord + 1) //clicked to the bottom right of the previous
                    EvenRowBotRight(hex);

                else if (hex.xCoord == last.xCoord - 1 && hex.yCoord == last.yCoord + 1) //clicked to the bottom left of the previous
                    EvenRowBotLeft(hex);

                else if (hex.xCoord == last.xCoord - 1 && hex.yCoord == last.yCoord) //clicked to the left of the previous
                    EvenRowLeft(hex);

                else if (hex.xCoord == last.xCoord - 1 && hex.yCoord == last.yCoord - 1) //clicked to the top left of the previous
                    EvenRowTopLeft(hex);

            }
            else if (_player.LastClicked.yCoord % 2 == 1) //odd row
            {
                if (hex.xCoord == last.xCoord + 1 && hex.yCoord == last.yCoord - 1) //clicked to the top right of the previous
                    OddRowTopRight(hex);

                else if (hex.xCoord == last.xCoord + 1 && hex.yCoord == last.yCoord) //clicked to the right of the previous 
                    OddRowRight(hex);

                else if (hex.xCoord == last.xCoord + 1 && hex.yCoord == last.yCoord + 1) //clicked to the bottom right of the previous
                    OddRowBotRight(hex);

                else if (hex.xCoord == last.xCoord && hex.yCoord == last.yCoord + 1) //clicked to the bottom left of the previous
                    OddRowBotLeft(hex);

                else if (hex.xCoord == last.xCoord - 1 && hex.yCoord == last.yCoord) //clicked to the left of the previous
                    OddRowLeft(hex);

                else if (hex.xCoord == last.xCoord && hex.yCoord == last.yCoord - 1) //clicked to the top left of the previous
                    OddRowTopLeft(hex);
            }

            //checking for player loss on the first move
            List<Hex> tmpCheckForLoss = new List<Hex>();

            for (int x = 0; x < _board.Width; x++)
                for (int y = 0; y < _board.Height; y++)
                {
                    if (_board.hexes[x, y].IsValid)
                        tmpCheckForLoss.Add(_board.hexes[x, y]);
                }

            if (tmpCheckForLoss.Count == 0)
            {
                _playerLost = true;
                _gameOn = false;
            }

            _player.LastClicked = hex;

        }

        public void TrySetValid(int x, int y)
        {

            try
            {
                if (_board.hexes[x, y].HexState.BackgroundColor == Color.WhiteSmoke)
                    _board.hexes[x, y].IsValid = true;

            }
            catch (IndexOutOfRangeException)
            {
            }
        }
        #endregion

        #region RowAdjustments
        private void EvenRowTopRight(Hex hex)
        {
            TrySetValid(hex.xCoord, hex.yCoord - 1);
            TrySetValid(hex.xCoord + 1, hex.yCoord - 1);
            TrySetValid(hex.xCoord + 1, hex.yCoord);
        }

        private void EvenRowRight(Hex hex)
        {
            TrySetValid(hex.xCoord, hex.yCoord - 1);
            TrySetValid(hex.xCoord + 1, hex.yCoord);
            TrySetValid(hex.xCoord, hex.yCoord + 1);
        }

        private void EvenRowBotRight(Hex hex)
        {
            TrySetValid(hex.xCoord + 1, hex.yCoord);
            TrySetValid(hex.xCoord + 1, hex.yCoord + 1);
            TrySetValid(hex.xCoord, hex.yCoord + 1);
        }

        private void EvenRowBotLeft(Hex hex)
        {
            TrySetValid(hex.xCoord + 1, hex.yCoord + 1);
            TrySetValid(hex.xCoord, hex.yCoord + 1);
            TrySetValid(hex.xCoord - 1, hex.yCoord);
        }

        private void EvenRowLeft(Hex hex)
        {
            TrySetValid(hex.xCoord - 1, hex.yCoord + 1);
            TrySetValid(hex.xCoord - 1, hex.yCoord);
            TrySetValid(hex.xCoord - 1, hex.yCoord - 1);
        }

        private void EvenRowTopLeft(Hex hex)
        {
            TrySetValid(hex.xCoord - 1, hex.yCoord);
            TrySetValid(hex.xCoord, hex.yCoord - 1);
            TrySetValid(hex.xCoord + 1, hex.yCoord - 1);
        }

        private void OddRowTopRight(Hex hex)
        {
            TrySetValid(hex.xCoord - 1, hex.yCoord - 1);
            TrySetValid(hex.xCoord, hex.yCoord - 1);
            TrySetValid(hex.xCoord + 1, hex.yCoord);
        }
        private void OddRowRight(Hex hex)
        {
            TrySetValid(hex.xCoord + 1, hex.yCoord - 1);
            TrySetValid(hex.xCoord + 1, hex.yCoord);
            TrySetValid(hex.xCoord + 1, hex.yCoord + 1);
        }
        private void OddRowBotRight(Hex hex)
        {
            TrySetValid(hex.xCoord + 1, hex.yCoord);
            TrySetValid(hex.xCoord, hex.yCoord + 1);
            TrySetValid(hex.xCoord - 1, hex.yCoord + 1);
        }

        private void OddRowBotLeft(Hex hex)
        {
            TrySetValid(hex.xCoord, hex.yCoord + 1);
            TrySetValid(hex.xCoord - 1, hex.yCoord + 1);
            TrySetValid(hex.xCoord - 1, hex.yCoord);
        }
        private void OddRowLeft(Hex hex)
        {
            TrySetValid(hex.xCoord, hex.yCoord + 1);
            TrySetValid(hex.xCoord - 1, hex.yCoord);
            TrySetValid(hex.xCoord, hex.yCoord - 1);
        }
        private void OddRowTopLeft(Hex hex)
        {
            TrySetValid(hex.xCoord - 1, hex.yCoord);
            TrySetValid(hex.xCoord - 1, hex.yCoord - 1);
            TrySetValid(hex.xCoord, hex.yCoord - 1);
        }

        #endregion

        #region RowAdjustmentsOpponent
        private void EvenRowTopRightOp(Hex hex)
        {
            TrySetValidOp(hex.xCoord, hex.yCoord - 1);
            TrySetValidOp(hex.xCoord + 1, hex.yCoord - 1);
            TrySetValidOp(hex.xCoord + 1, hex.yCoord);
        }

        private void EvenRowRightOp(Hex hex)
        {
            TrySetValidOp(hex.xCoord, hex.yCoord - 1);
            TrySetValidOp(hex.xCoord + 1, hex.yCoord);
            TrySetValidOp(hex.xCoord, hex.yCoord + 1);
        }

        private void EvenRowBotRightOp(Hex hex)
        {
            TrySetValidOp(hex.xCoord + 1, hex.yCoord);
            TrySetValidOp(hex.xCoord + 1, hex.yCoord + 1);
            TrySetValidOp(hex.xCoord, hex.yCoord + 1);
        }

        private void EvenRowBotLeftOp(Hex hex)
        {
            TrySetValidOp(hex.xCoord + 1, hex.yCoord + 1);
            TrySetValidOp(hex.xCoord, hex.yCoord + 1);
            TrySetValidOp(hex.xCoord - 1, hex.yCoord);
        }

        private void EvenRowLeftOp(Hex hex)
        {
            TrySetValidOp(hex.xCoord - 1, hex.yCoord + 1);
            TrySetValidOp(hex.xCoord - 1, hex.yCoord);
            TrySetValidOp(hex.xCoord - 1, hex.yCoord - 1);
        }

        private void EvenRowTopLeftOp(Hex hex)
        {
            TrySetValidOp(hex.xCoord - 1, hex.yCoord);
            TrySetValidOp(hex.xCoord, hex.yCoord - 1);
            TrySetValidOp(hex.xCoord + 1, hex.yCoord - 1);
        }

        private void OddRowTopRightOp(Hex hex)
        {
            TrySetValidOp(hex.xCoord - 1, hex.yCoord - 1);
            TrySetValidOp(hex.xCoord, hex.yCoord - 1);
            TrySetValidOp(hex.xCoord + 1, hex.yCoord);
        }
        private void OddRowRightOp(Hex hex)
        {
            TrySetValidOp(hex.xCoord + 1, hex.yCoord - 1);
            TrySetValidOp(hex.xCoord + 1, hex.yCoord);
            TrySetValidOp(hex.xCoord + 1, hex.yCoord + 1);
        }
        private void OddRowBotRightOp(Hex hex)
        {
            TrySetValidOp(hex.xCoord + 1, hex.yCoord);
            TrySetValidOp(hex.xCoord, hex.yCoord + 1);
            TrySetValidOp(hex.xCoord - 1, hex.yCoord + 1);
        }

        private void OddRowBotLeftOp(Hex hex)
        {
            TrySetValidOp(hex.xCoord, hex.yCoord + 1);
            TrySetValidOp(hex.xCoord - 1, hex.yCoord + 1);
            TrySetValidOp(hex.xCoord - 1, hex.yCoord);
        }
        private void OddRowLeftOp(Hex hex)
        {
            TrySetValidOp(hex.xCoord, hex.yCoord + 1);
            TrySetValidOp(hex.xCoord - 1, hex.yCoord);
            TrySetValidOp(hex.xCoord, hex.yCoord - 1);
        }
        private void OddRowTopLeftOp(Hex hex)
        {
            TrySetValidOp(hex.xCoord - 1, hex.yCoord);
            TrySetValidOp(hex.xCoord - 1, hex.yCoord - 1);
            TrySetValidOp(hex.xCoord, hex.yCoord - 1);
        }
        public void TrySetValidOp(int x, int y)
        {

            try
            {
                if (_board.hexes[x, y].HexState.BackgroundColor == Color.WhiteSmoke)
                    _board.hexes[x, y].OpponentValid = true;
            }
            catch (IndexOutOfRangeException)
            {
            }
        }

        #endregion

        #region Opponent Movements
        private void MainOpponentMove(Hex playerLastClick)
        {
            foreach (var op in _opponents)
            {
                if (!op.IsAlive)
                    continue;

                Thread.Sleep(200);
                for (int i = _movesLeft; i > 0; i--)
                {
                    Thread.Sleep(400);
                    Console.WriteLine("===============================");
                    Console.WriteLine($"Moving Opponent: {op.Name}");
                    op.ValidMoves.Clear();
                    ClearValidOpponentMoves(); //reset all hexes as false
                    if (op.IsFirstTurn)
                    {
                        op.LastClicked = _board.hexes[op.Position[0], op.Position[1]]; //set lastposition to the same as the starting position
                        UpdateValidMovesFirstTurnOpponent(_board.hexes[op.Position[0], op.Position[1]], op); //set all neighboring hexes as valid
                        Console.WriteLine($"its {op.Name}'s first turn, starting from X: {op.Position[0]} Y:{op.Position[1]}");
                        op.IsFirstTurn = false;
                    }
                    else
                    {
                        UpdateValidMovesOpponent(_board.hexes[op.Position[0], op.Position[1]], op);
                    }

                    Console.WriteLine($"{op.Name}'s position is X: {op.Position[0]} Y:{op.Position[1]} - Previous position was X: {op.LastClicked.xCoord} Y: {op.LastClicked.yCoord}");
                    Console.WriteLine("Starting movement sequence");
                    Console.WriteLine("___________________________________");
                    MoveOpponent(op);
                }

            }
            Thread.Sleep(600);

            UpdateValidMoves(playerLastClick);

            List<Hex> tmpCheck = new List<Hex>();
            foreach (var item in _board.hexes)
            {
                if (item.IsValid)
                    tmpCheck.Add(item);
            }
            if (tmpCheck.Count == 0)
                _gameOn = false;

            _player.MyTurn = true;
        }

        private void UpdateValidMovesFirstTurnOpponent(Hex hex, Opponent op)
        {
            if (hex.yCoord % 2 == 0) //even row
            {
                if (_board.hexes[hex.xCoord, hex.yCoord - 1].HexState.BackgroundColor == Color.WhiteSmoke)
                    _board.hexes[hex.xCoord, hex.yCoord - 1].OpponentValid = true; //top right

                if (_board.hexes[hex.xCoord + 1, hex.yCoord].HexState.BackgroundColor == Color.WhiteSmoke)
                    _board.hexes[hex.xCoord + 1, hex.yCoord].OpponentValid = true; //right

                if (_board.hexes[hex.xCoord, hex.yCoord + 1].HexState.BackgroundColor == Color.WhiteSmoke)
                    _board.hexes[hex.xCoord, hex.yCoord + 1].OpponentValid = true; //bottom right

                if (_board.hexes[hex.xCoord - 1, hex.yCoord + 1].HexState.BackgroundColor == Color.WhiteSmoke)
                    _board.hexes[hex.xCoord - 1, hex.yCoord + 1].OpponentValid = true; //bottom left

                if (_board.hexes[hex.xCoord - 1, hex.yCoord].HexState.BackgroundColor == Color.WhiteSmoke)
                    _board.hexes[hex.xCoord - 1, hex.yCoord].OpponentValid = true; //left

                if (_board.hexes[hex.xCoord - 1, hex.yCoord - 1].HexState.BackgroundColor == Color.WhiteSmoke)
                    _board.hexes[hex.xCoord - 1, hex.yCoord - 1].OpponentValid = true; //top left

            }
            else if (hex.yCoord % 2 == 1)//odd row
            {
                if (_board.hexes[hex.xCoord + 1, hex.yCoord - 1].HexState.BackgroundColor == Color.WhiteSmoke)
                    _board.hexes[hex.xCoord + 1, hex.yCoord - 1].OpponentValid = true; //top right

                if (_board.hexes[hex.xCoord + 1, hex.yCoord].HexState.BackgroundColor == Color.WhiteSmoke)
                    _board.hexes[hex.xCoord + 1, hex.yCoord].OpponentValid = true; //right

                if (_board.hexes[hex.xCoord + 1, hex.yCoord + 1].HexState.BackgroundColor == Color.WhiteSmoke)
                    _board.hexes[hex.xCoord + 1, hex.yCoord + 1].OpponentValid = true; //bottom right

                if (_board.hexes[hex.xCoord, hex.yCoord + 1].HexState.BackgroundColor == Color.WhiteSmoke)
                    _board.hexes[hex.xCoord, hex.yCoord + 1].OpponentValid = true; //bottom left

                if (_board.hexes[hex.xCoord - 1, hex.yCoord].HexState.BackgroundColor == Color.WhiteSmoke)
                    _board.hexes[hex.xCoord - 1, hex.yCoord].OpponentValid = true; //left

                if (_board.hexes[hex.xCoord, hex.yCoord - 1].HexState.BackgroundColor == Color.WhiteSmoke)
                    _board.hexes[hex.xCoord, hex.yCoord - 1].OpponentValid = true; //top left
            }

        }

        private void UpdateValidMovesOpponent(Hex hex, Opponent op)
        {
            Hex last = _board.hexes[op.LastClicked.xCoord, op.LastClicked.yCoord];

            if (last.yCoord % 2 == 0) // even row
            {
                if (hex.xCoord == last.xCoord && hex.yCoord == last.yCoord - 1) //clicked to the top right of the previous
                    EvenRowTopRightOp(hex);

                else if (hex.xCoord == last.xCoord + 1 && hex.yCoord == last.yCoord) //clicked to the right of the previous 
                    EvenRowRightOp(hex);

                else if (hex.xCoord == last.xCoord && hex.yCoord == last.yCoord + 1) //clicked to the bottom right of the previous
                    EvenRowBotRightOp(hex);

                else if (hex.xCoord == last.xCoord - 1 && hex.yCoord == last.yCoord + 1) //clicked to the bottom left of the previous
                    EvenRowBotLeftOp(hex);

                else if (hex.xCoord == last.xCoord - 1 && hex.yCoord == last.yCoord) //clicked to the left of the previous
                    EvenRowLeftOp(hex);

                else if (hex.xCoord == last.xCoord - 1 && hex.yCoord == last.yCoord - 1) //clicked to the top left of the previous
                    EvenRowTopLeftOp(hex);

            }
            else if (last.yCoord % 2 == 1) //odd row
            {
                if (hex.xCoord == last.xCoord + 1 && hex.yCoord == last.yCoord - 1) //clicked to the top right of the previous
                    OddRowTopRightOp(hex);

                else if (hex.xCoord == last.xCoord + 1 && hex.yCoord == last.yCoord) //clicked to the right of the previous 
                    OddRowRightOp(hex);

                else if (hex.xCoord == last.xCoord + 1 && hex.yCoord == last.yCoord + 1) //clicked to the bottom right of the previous
                    OddRowBotRightOp(hex);

                else if (hex.xCoord == last.xCoord && hex.yCoord == last.yCoord + 1) //clicked to the bottom left of the previous
                    OddRowBotLeftOp(hex);

                else if (hex.xCoord == last.xCoord - 1 && hex.yCoord == last.yCoord) //clicked to the left of the previous
                    OddRowLeftOp(hex);

                else if (hex.xCoord == last.xCoord && hex.yCoord == last.yCoord - 1) //clicked to the top left of the previous
                    OddRowTopLeftOp(hex);
            }

        }

        //todo AI
        private int UpdateValidMovesHex(Opponent op, Hex hex)
        {
            int ret = 0;

            Hex last = _board.hexes[op.Position[0], op.Position[1]];

            if (last.yCoord % 2 == 0) // even row
            {
                if (hex.xCoord == last.xCoord && hex.yCoord == last.yCoord - 1) //clicked to the top right of the previous
                    ret = EvenRowTopRightHex(hex);

                else if (hex.xCoord == last.xCoord + 1 && hex.yCoord == last.yCoord) //clicked to the right of the previous 
                    ret = EvenRowRightHex(hex);

                else if (hex.xCoord == last.xCoord && hex.yCoord == last.yCoord + 1) //clicked to the bottom right of the previous
                    ret = EvenRowBotRightHex(hex);

                else if (hex.xCoord == last.xCoord - 1 && hex.yCoord == last.yCoord + 1) //clicked to the bottom left of the previous
                    ret = EvenRowBotLeftHex(hex);

                else if (hex.xCoord == last.xCoord - 1 && hex.yCoord == last.yCoord) //clicked to the left of the previous
                    ret = EvenRowLeftHex(hex);

                else if (hex.xCoord == last.xCoord - 1 && hex.yCoord == last.yCoord - 1) //clicked to the top left of the previous
                    ret = EvenRowTopLeftHex(hex);

            }
            else if (last.yCoord % 2 == 1) //odd row
            {
                if (hex.xCoord == last.xCoord + 1 && hex.yCoord == last.yCoord - 1) //clicked to the top right of the previous
                    ret = OddRowTopRightHex(hex);

                else if (hex.xCoord == last.xCoord + 1 && hex.yCoord == last.yCoord) //clicked to the right of the previous 
                    ret = OddRowRightHex(hex);

                else if (hex.xCoord == last.xCoord + 1 && hex.yCoord == last.yCoord + 1) //clicked to the bottom right of the previous
                    ret = OddRowBotRightHex(hex);

                else if (hex.xCoord == last.xCoord && hex.yCoord == last.yCoord + 1) //clicked to the bottom left of the previous
                    ret = OddRowBotLeftHex(hex);

                else if (hex.xCoord == last.xCoord - 1 && hex.yCoord == last.yCoord) //clicked to the left of the previous
                    ret = OddRowLeftHex(hex);

                else if (hex.xCoord == last.xCoord && hex.yCoord == last.yCoord - 1) //clicked to the top left of the previous
                    ret = OddRowTopLeftHex(hex);
            }


            return ret;
        }

        private int EvenRowTopRightHex(Hex hex)
        {
            int ret = 0;
            ret += TrySetValidHex(hex.xCoord, hex.yCoord - 1);
            ret += TrySetValidHex(hex.xCoord + 1, hex.yCoord - 1);
            ret += TrySetValidHex(hex.xCoord + 1, hex.yCoord);
            return ret;
        }

        private int EvenRowRightHex(Hex hex)
        {
            int ret = 0;
            ret += TrySetValidHex(hex.xCoord, hex.yCoord - 1);
            ret += TrySetValidHex(hex.xCoord + 1, hex.yCoord);
            ret += TrySetValidHex(hex.xCoord, hex.yCoord + 1);
            return ret;
        }

        private int EvenRowBotRightHex(Hex hex)
        {
            int ret = 0;
            ret += TrySetValidHex(hex.xCoord + 1, hex.yCoord);
            ret += TrySetValidHex(hex.xCoord + 1, hex.yCoord + 1);
            ret += TrySetValidHex(hex.xCoord, hex.yCoord + 1);
            return ret;
        }

        private int EvenRowBotLeftHex(Hex hex)
        {
            int ret = 0;
            ret += TrySetValidHex(hex.xCoord + 1, hex.yCoord + 1);
            ret += TrySetValidHex(hex.xCoord, hex.yCoord + 1);
            ret += TrySetValidHex(hex.xCoord - 1, hex.yCoord);
            return ret;
        }

        private int EvenRowLeftHex(Hex hex)
        {
            int ret = 0;
            ret += TrySetValidHex(hex.xCoord - 1, hex.yCoord + 1);
            ret += TrySetValidHex(hex.xCoord - 1, hex.yCoord);
            ret += TrySetValidHex(hex.xCoord - 1, hex.yCoord - 1);
            return ret;
        }

        private int EvenRowTopLeftHex(Hex hex)
        {
            int ret = 0;
            ret += TrySetValidHex(hex.xCoord - 1, hex.yCoord);
            ret += TrySetValidHex(hex.xCoord, hex.yCoord - 1);
            ret += TrySetValidHex(hex.xCoord + 1, hex.yCoord - 1);
            return ret;
        }

        private int OddRowTopRightHex(Hex hex)
        {
            int ret = 0;
            ret += TrySetValidHex(hex.xCoord - 1, hex.yCoord - 1);
            ret += TrySetValidHex(hex.xCoord, hex.yCoord - 1);
            ret += TrySetValidHex(hex.xCoord + 1, hex.yCoord);
            return ret;
        }
        private int OddRowRightHex(Hex hex)
        {
            int ret = 0;
            ret += TrySetValidHex(hex.xCoord + 1, hex.yCoord - 1);
            ret += TrySetValidHex(hex.xCoord + 1, hex.yCoord);
            ret += TrySetValidHex(hex.xCoord + 1, hex.yCoord + 1);
            return ret;
        }
        private int OddRowBotRightHex(Hex hex)
        {
            int ret = 0;
            ret += TrySetValidHex(hex.xCoord + 1, hex.yCoord);
            ret += TrySetValidHex(hex.xCoord, hex.yCoord + 1);
            ret += TrySetValidHex(hex.xCoord - 1, hex.yCoord + 1);
            return ret;
        }

        private int OddRowBotLeftHex(Hex hex)
        {
            int ret = 0;
            ret += TrySetValidHex(hex.xCoord, hex.yCoord + 1);
            ret += TrySetValidHex(hex.xCoord - 1, hex.yCoord + 1);
            ret += TrySetValidHex(hex.xCoord - 1, hex.yCoord);
            return ret;
        }
        private int OddRowLeftHex(Hex hex)
        {
            int ret = 0;
            ret += TrySetValidHex(hex.xCoord, hex.yCoord + 1);
            ret += TrySetValidHex(hex.xCoord - 1, hex.yCoord);
            ret += TrySetValidHex(hex.xCoord, hex.yCoord - 1);
            return ret;
        }
        private int OddRowTopLeftHex(Hex hex)
        {
            int ret = 0;
            ret += TrySetValidHex(hex.xCoord - 1, hex.yCoord);
            ret += TrySetValidHex(hex.xCoord - 1, hex.yCoord - 1);
            ret += TrySetValidHex(hex.xCoord, hex.yCoord - 1);
            return ret;
        }

        public int TrySetValidHex(int x, int y)
        {
            int ret = 0;
            try
            {
                if (_board.hexes[x, y].HexState.BackgroundColor == Color.WhiteSmoke)
                    ret = 1;
            }
            catch (IndexOutOfRangeException)
            {
            }

            return ret;
        }

        private void MoveOpponent(Opponent op)
        {
            for (int x = 0; x < _board.Width; x++)
                for (int y = 0; y < _board.Height; y++)
                {
                    if (_board.hexes[x, y].OpponentValid)
                        op.ValidMoves.Add(_board.hexes[x, y]);
                }

            //todo evalute which move is the best

            if (op.ValidMoves.Count > 1)
                foreach (var item in op.ValidMoves)
                {
                    item.PossibleMoves = UpdateValidMovesHex(op, item);
                }

            if (op.ValidMoves.Count != 0)
            {
                foreach (var item in op.ValidMoves)
                    Console.WriteLine($"x: {item.xCoord} y: {item.yCoord} is valid for {op.Name} || it has {item.PossibleMoves} possible moves next turn.");

                var max = op.ValidMoves.Max(obj => obj.PossibleMoves);
                Hex[] tmpMoves = op.ValidMoves.Where(obj => obj.PossibleMoves == max).ToArray();

                int idx = rnd.Next(0, tmpMoves.Count());
                Console.WriteLine($"Result: {tmpMoves.Count()} good move(s) for the next turn, randomized X: {tmpMoves[idx].xCoord} Y: {tmpMoves[idx].yCoord}");

                op.LastClicked = _board.hexes[op.Position[0], op.Position[1]];
                _board.BoardState.ActiveHexes.Remove(_board.hexes[op.Position[0], op.Position[1]]);
                op.Position[0] = tmpMoves[idx].xCoord;
                op.Position[1] = tmpMoves[idx].yCoord;
                _board.BoardState.ActiveHexes.Add(_board.hexes[op.Position[0], op.Position[1]]);


                _board.hexes[tmpMoves[idx].xCoord, tmpMoves[idx].yCoord].HexState.BackgroundColor = op.Color;

            }
            else
            {
                Console.WriteLine($"{op.Name} Lost!");
                _windowRef.OpponentLost(_opponents.IndexOf(op));
                op.IsAlive = false;
                if (_opponents.Count(x => x.IsAlive) == 0)
                {
                    _gameOn = false;
                    _showWin = new Thread(() => _windowRef.ShowWin());
                    _showWin.Start();
                }
            }




        }
        private void SetOpponentStartFalse(int x, int y)
        {
            if (y % 2 == 0)
            {
                _board.hexes[x, y].OpponentValid = false;
                _board.hexes[x, y - 1].OpponentValid = false;
                _board.hexes[x + 1, y].OpponentValid = false;
                _board.hexes[x, y + 1].OpponentValid = false;
                _board.hexes[x - 1, y + 1].OpponentValid = false;
                _board.hexes[x - 1, y].OpponentValid = false;
                _board.hexes[x - 1, y - 1].OpponentValid = false;

            }
            else
            {
                _board.hexes[x, y].OpponentValid = false;
                _board.hexes[x + 1, y - 1].OpponentValid = false;
                _board.hexes[x + 1, y].OpponentValid = false;
                _board.hexes[x + 1, y + 1].OpponentValid = false;
                _board.hexes[x, y + 1].OpponentValid = false;
                _board.hexes[x - 1, y].OpponentValid = false;
                _board.hexes[x, y - 1].OpponentValid = false;
            }
        }

        private void TryPlacingAI()
        {
            foreach (var opponent in _opponents)
            {
                bool placementValid = false;
                do
                {
                    int tryX = Randomizer.Rng(1, _board.Width - 1);
                    int tryY = Randomizer.Rng(1, _board.Height - 1);

                    if (_board.hexes[tryX, tryY].OpponentValid)
                    {
                        Thread.Sleep(1000);
                        int[] tmpStart = new int[2] { tryX, tryY };
                        opponent.Position = tmpStart;
                        _board.hexes[tryX, tryY].HexState.BackgroundColor = opponent.Color;
                        SetOpponentStartFalse(tryX, tryY);
                        Console.WriteLine($"Placing {opponent.Name} at x: {tryX} y: {tryY}");
                        _board.BoardState.ActiveHexes.Add(_board.hexes[tryX, tryY]);
                        placementValid = true;
                    }

                } while (!placementValid);
            }
        }

        private void SetAIstartPositions(Hex clickedHex)
        {
            for (int x = 1; x < _board.Width - 1; x++)
                for (int y = 1; y < _board.Height - 1; y++)
                {
                    _board.hexes[x, y].OpponentValid = true;
                }

            for (int x = 1; x < _board.Width - 1; x++)
                for (int y = 1; y < _board.Height - 1; y++)
                {
                    if (_board.hexes[x, y].HexState.BackgroundColor == _player.Color)
                    {
                        Console.WriteLine($"Player has chosen start position x: {x} y: {y}");
                        SetOpponentStartFalse(x, y);
                    }
                }

            TryPlacingAI();
            UpdateValidMovesFirstTurn(clickedHex);

            _player.MyTurn = true;
        }

        #endregion

        public void DoFirstTurn()
        {
            Hex hex = null;

            for (int x = 1; x < _board.Width - 1; x++)
            {
                for (int y = 1; y < _board.Height - 1; y++)
                {
                    if (_board.hexes[x, y].HexState.BackgroundColor == _player.Color)
                    {
                        hex = _board.hexes[x, y];
                    }
                }
            }

            if (hex.yCoord % 2 == 0) //even row
            {
                _board.hexes[hex.xCoord, hex.yCoord - 1].IsValid = true; //top right
                _board.hexes[hex.xCoord + 1, hex.yCoord].IsValid = true; //right
                _board.hexes[hex.xCoord, hex.yCoord + 1].IsValid = true; //bottom right
                _board.hexes[hex.xCoord - 1, hex.yCoord + 1].IsValid = true; //bottom left
                _board.hexes[hex.xCoord - 1, hex.yCoord].IsValid = true; //left
                _board.hexes[hex.xCoord - 1, hex.yCoord - 1].IsValid = true; //top left

            }
            else if (hex.yCoord % 2 == 1)//odd row
            {
                _board.hexes[hex.xCoord + 1, hex.yCoord - 1].IsValid = true; //top right
                _board.hexes[hex.xCoord + 1, hex.yCoord].IsValid = true; //right
                _board.hexes[hex.xCoord + 1, hex.yCoord + 1].IsValid = true; //bottom right
                _board.hexes[hex.xCoord, hex.yCoord + 1].IsValid = true; //bottom left
                _board.hexes[hex.xCoord - 1, hex.yCoord].IsValid = true; //left
                _board.hexes[hex.xCoord, hex.yCoord - 1].IsValid = true; //top left
            }

            _player.LastClicked = hex;
        }

        public void DoRegularTurn ()
        {
            UpdateValidMoves(_player.Position);
        }

        public void MouseClicked(object sender, MouseEventArgs e, int xOffset, int yOffset)
        {
            Point mouseClick = new Point(e.X - xOffset, e.Y - yOffset);
            Hex clickedHex = _board.FindHexMouseClick(mouseClick);

            if (isMultiPlayer)
            {
                if (clickedHex != null && mpStartingTurn && clickedHex.IsValid)
                {
                    int[] tmpMove = new int[2];
                    tmpMove[0] = clickedHex.xCoord;
                    tmpMove[1] = clickedHex.yCoord;
                    List<int[]> tmpMoveList = new List<int[]>();
                    tmpMoveList.Add(tmpMove);


                    int myIndex = 0;

                    for (int i = 0; i < _windowRef.MPplayerArray.Count(); i++)
                    {
                        if (_windowRef.MPplayerArray[i].Name == _player.Name)
                        {
                            myIndex = i;
                        }
                    }
                    myIndex++;

                    PlayMessage pm = new PlayMessage(_player.Name);

                    if (myIndex < _windowRef.MPplayerArray.Count())
                    {
                        pm = new PlayMessage(_player.Name)
                        {
                            HostName = _windowRef._currentLobby.HostName,
                            IsAlive = true,
                            MoveList = tmpMoveList,
                            Sender = "client",
                            UserName = _player.Name,
                            ThisPlayer = _player,
                            NextUser = _windowRef.MPplayerArray[myIndex],
                            StartTurn = 0
                        };

                    }
                    else
                    {
                        pm = new PlayMessage(_player.Name)
                        {
                            HostName = _windowRef._currentLobby.HostName,
                            IsAlive = true,
                            MoveList = tmpMoveList,
                            Sender = "client",
                            UserName = _player.Name,
                            ThisPlayer = _player,
                            NextUser = _windowRef.MPplayerArray[0],
                            StartTurn = 1
                        };
                    }

                    _windowRef._nwc.Send(MessageHandler.Serialize(pm));
                    clickedHex.HexState.BackgroundColor = _player.Color;
                    _board.BoardState.ActiveHexes.Add(clickedHex);
                    ClearValidMoves();
                    mpStartingTurn = false;


                }
                else if (clickedHex != null && clickedHex.IsValid)
                {
                    List<int[]> tmpMoveList = new List<int[]>();

                    if (mpStillmyturn)
                    {
                        mpStillmyturn = false;

                        int[] tmpMove = new int[2];
                        tmpMove[0] = clickedHex.xCoord;
                        tmpMove[1] = clickedHex.yCoord;
                        tmpMoveList.Add(tmpMove);
                        _board.BoardState.ActiveHexes.Remove(_player.LastClicked);
                        _board.BoardState.ActiveHexes.Add(clickedHex);
                        clickedHex.HexState.BackgroundColor = _player.Color;
                        ClearValidMoves();
                        UpdateValidMoves(clickedHex);

                        PlayMessage pm = new PlayMessage(_player.Name)
                        {
                            HostName = _windowRef._currentLobby.HostName,
                            IsAlive = true,
                            MoveList = tmpMoveList,
                            Sender = "client",
                            UserName = _player.Name,
                            ThisPlayer = _player,
                            NextUser = _player,
                            StartTurn = 2

                        };
                        Console.WriteLine("sending playmessage with next player: " + pm.NextUser.Name);
                        _windowRef._nwc.Send(MessageHandler.Serialize(pm));
                    }
                    else
                    {
                        int myIndex = 0;

                        for (int q = 0; q < _windowRef.MPplayerArray.Count(); q++)
                        {
                            if (_windowRef.MPplayerArray[q].Name == _player.Name)
                            {
                                myIndex = q;
                            }
                        }
                        myIndex++;

                        if (myIndex == _windowRef.MPplayerArray.Count())
                            myIndex = 0;

                        PlayMessage pm = new PlayMessage(_player.Name)
                        {
                            HostName = _windowRef._currentLobby.HostName,
                            IsAlive = true,
                            MoveList = tmpMoveList,
                            Sender = "client",
                            UserName = _player.Name,
                            ThisPlayer = _player,
                            NextUser = _windowRef.MPplayerArray[myIndex],
                            StartTurn = 2
                        };
                        Console.WriteLine("sending playmessage with next player: " + pm.NextUser.Name);

                        _windowRef._nwc.Send(MessageHandler.Serialize(pm));
                        ClearValidMoves();
                        mpStillmyturn = true;
                    }


                }


            }


            if (isMultiPlayer == false)
            {
                int livingop = 0;
                foreach (Opponent op in _opponents)
                {
                    if (op.IsAlive) livingop++;
                }
                if (livingop == 0) _windowRef.ShowWin();

                if (clickedHex != null && _gameOn)
                {
                    if (_player.IsFirstTurn && clickedHex.IsValid)
                    {
                        clickedHex.HexState.BackgroundColor = _player.Color;
                        _board.BoardState.ActiveHexes.Add(clickedHex);
                        _player.IsFirstTurn = false;
                        _player.MyTurn = false;
                        ClearValidMoves();
                        AiPlacer = new Thread(() => SetAIstartPositions(clickedHex));
                        AiPlacer.Start();

                    }
                    else if (_player.MyTurn && clickedHex.IsValid)
                    {
                        _board.BoardState.ActiveHexes.Remove(_player.LastClicked);
                        _board.BoardState.ActiveHexes.Add(clickedHex);
                        clickedHex.HexState.BackgroundColor = _player.Color;
                        ClearValidMoves();
                        _movesLeft--;
                        if (_movesLeft == 0)
                        {
                            _player.MyTurn = false;
                            _movesLeft = 2;
                            AiMover = new Thread(() => MainOpponentMove(clickedHex));
                            AiMover.Start();
                            //if (!_opponents.Any(x => x.IsAlive))
                            //    _gameOn = false;
                        }
                        else
                        {
                            UpdateValidMoves(clickedHex);

                        }


                    }
                    else //new code
                    {
                        //UpdateValidMoves(clickedHex);
                        int validmoves = 0;
                        foreach (Hex x in _board.hexes)
                        {
                            if (x.IsValid)
                                validmoves++;
                        }
                        if (validmoves == 0 && _player.MyTurn == true)
                        {
                            _windowRef.ShowLoss();
                        }
                    }
                }

                if (!_gameOn && _playerLost)
                {
                    _windowRef.ShowLoss();
                }
            }
        } // MouseClicked
    }
}
