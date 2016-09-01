using GameLogic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeBattle2
{
    public class MPGame
    {
        Board _board;
        int _numberOfPlayers;
        public Player _player;
        private Color[] _availableColors;
        private List<Opponent> _opponents;
        private int _movesLeft = 2;
        SnakeBattle2 _windowRef;
        Random rnd = new Random();
        bool _gameOn;
        bool _playerLost;

        public MPGame(Board board, int numberOfPlayers, Player player, Color[] availableColors, SnakeBattle2 windowRef)
        {
            _windowRef = windowRef;
            _movesLeft = 2;
            _board = board;
            _numberOfPlayers = numberOfPlayers;
            _player = player;
            _player.MyTurn = true;
            _player.IsFirstTurn = true;
            _availableColors = availableColors;
            _gameOn = true;
            _playerLost = false;
            _opponents = new List<Opponent>();
            //CreateOpponents();
            //enable all hexes except edges as valid moves for current player
            for (int x = 1; x < _board.Width - 1; x++)
                for (int y = 1; y < _board.Height - 1; y++)
                {
                    _board.hexes[x, y].IsValid = true;
                }

        }
    }
}
