using GameLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeBattle2
{
    public partial class SnakeBattle2 : Form
    {
        Board _board;
        GraphicsEngine graphicsEngine;
        int _xOffset = 20;
        int _yOffset = 20;
        int _hexSize = 30;
        int _borderWidth = 2;
        public Color[] availableColors;
        Game _currentGame;
        public SnakeBattle2()
        {
            this.BackColor = Color.Black;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.DoubleBuffered = true;
            InitializeComponent();
            GoToMainMenu();
            availableColors = new Color[8] { Color.Red, Color.Blue, Color.Yellow, Color.Green, Color.Gray, Color.HotPink, Color.DarkOrange, Color.Purple };
            for (int i = 2; i <= 8; i++)
                comboBoxPlayers.Items.Add(i);
            for (int i = 8; i <= 15; i++)
                comboBoxFieldSize.Items.Add(i);
            foreach (var item in availableColors)
                comboBoxMyColor.Items.Add(item.Name);

            buttonWin.Location = new System.Drawing.Point(27, 280);
            buttonOpponent0.UseVisualStyleBackColor = false;
            buttonOpponent1.UseVisualStyleBackColor = false;
            buttonOpponent2.UseVisualStyleBackColor = false;
            buttonOpponent3.UseVisualStyleBackColor = false;
            buttonOpponent4.UseVisualStyleBackColor = false;
            buttonOpponent5.UseVisualStyleBackColor = false;
            buttonOpponent6.UseVisualStyleBackColor = false;
            labelXY.Text = " ";
            labelXY.Hide();
            Console.WriteLine("Welcome to Snake Battle 2");

        }

        public void comboBoxMyColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            if (e.Index >= 0)
            {
                string n = ((ComboBox)sender).Items[e.Index].ToString();
                Color c = Color.FromName(n);
                Brush b = new SolidBrush(c);
                g.FillRectangle(b, rect.X, rect.Y + 5,
                                rect.Width - 10, rect.Height - 10);
            }
        }

        public void GoToMainMenu ()
        {
            buttonWin.Hide();
            buttonNewSP.Show();
            buttonNewMP.Show();
            comboBoxPlayers.Hide();
            comboBoxFieldSize.Hide();
            labelNumberOfPlayers.Hide();
            labelFieldSize.Hide();
            buttonStartGame.Hide();
            labelMyColor.Hide();
            comboBoxMyColor.Hide();
            buttonQuitGame.Hide();

            buttonConnect.Hide();
            labelConnect.Hide();
            textBoxConnect.Hide();
            buttonUserName.Hide();
            labelUserName.Hide();
            textBoxUserName.Hide();
            buttonEnterServer.Hide();

            buttonOpponent0.Hide();
            buttonOpponent1.Hide();
            buttonOpponent2.Hide();
            buttonOpponent3.Hide();
            buttonOpponent4.Hide();
            buttonOpponent5.Hide();
            buttonOpponent6.Hide();
            buttonOpponent7.Hide();

            labelOpponent0.Hide();
            labelOpponent1.Hide();
            labelOpponent2.Hide();
            labelOpponent3.Hide();
            labelOpponent4.Hide();
            labelOpponent5.Hide();
            labelOpponent6.Hide();
            labelOpponent7.Hide();
        }

        public void GoToGameOptions()
        {
            buttonWin.Hide();
            buttonNewMP.Hide();
            buttonNewSP.Hide();
            comboBoxPlayers.Show();
            comboBoxFieldSize.Show();
            labelNumberOfPlayers.Show();
            labelFieldSize.Show();
            labelMyColor.Show();
            comboBoxMyColor.Show();
            comboBoxPlayers.SelectedIndex = 0; comboBoxFieldSize.SelectedIndex = 0; comboBoxMyColor.SelectedIndex = 0;
            buttonStartGame.Show();
            buttonQuitGame.Hide();

            buttonConnect.Hide();
            labelConnect.Hide();
            textBoxConnect.Hide();
            buttonUserName.Hide();
            labelUserName.Hide();
            textBoxUserName.Hide();
            buttonEnterServer.Hide();

            buttonOpponent0.Hide();
            buttonOpponent1.Hide();
            buttonOpponent2.Hide();
            buttonOpponent3.Hide();
            buttonOpponent4.Hide();
            buttonOpponent5.Hide();
            buttonOpponent6.Hide();
            buttonOpponent7.Hide();

            labelOpponent0.Hide();
            labelOpponent1.Hide();
            labelOpponent2.Hide();
            labelOpponent3.Hide();
            labelOpponent4.Hide();
            labelOpponent5.Hide();
            labelOpponent7.Hide();
            labelOpponent6.Hide();
        }

        public void GoToGame()
        {
            Player player = new Player ( "Player 1", Color.FromName(comboBoxMyColor.SelectedItem.ToString()) );
            int numberOfPlayers = Convert.ToInt32(comboBoxPlayers.Text);
            Color playerColor = Color.FromName(comboBoxMyColor.SelectedItem.ToString());
            buttonWin.Hide();
            labelNumberOfPlayers.Hide();
            labelFieldSize.Hide();
            comboBoxPlayers.Hide();
            comboBoxFieldSize.Hide();
            buttonQuitGame.Show();
            buttonStartGame.Hide();
            labelMyColor.Hide();
            comboBoxMyColor.Hide();

            buttonConnect.Hide();
            labelConnect.Hide();
            textBoxConnect.Hide();
            buttonUserName.Hide();
            labelUserName.Hide();
            textBoxUserName.Hide();
            buttonEnterServer.Hide();

            Board board = new Board(Convert.ToInt32(comboBoxFieldSize.Text),
            Convert.ToInt32(comboBoxFieldSize.Text), _hexSize, HexOrientation.Pointy);

            board.BoardState.BackgroundColor = Color.Black; //background color of gameboard
            board.BoardState.GridPenWidth = _borderWidth;
            board.BoardState.ActiveHexBorderColor = Color.Red;
            board.BoardState.ActiveHexBorderWidth = _borderWidth;

            _currentGame = new Game(board, numberOfPlayers, player, availableColors, this);

            this._board = board;
            this.graphicsEngine = new GraphicsEngine(board, _xOffset, _yOffset, _currentGame);
        }

        public void GoToConnectToServer()
        {
            buttonConnect.Show();
            textBoxConnect.Show();
            labelConnect.Show();

            buttonUserName.Show();
            buttonUserName.Enabled = false;
            labelUserName.Show();
            textBoxUserName.Show();
            textBoxUserName.Enabled = false;

            buttonEnterServer.Show();
            buttonEnterServer.Enabled = false;

            buttonNewMP.Hide();
            buttonNewSP.Hide();

        }

        private void buttonNewSP_Click(object sender, EventArgs e)
        {
            GoToGameOptions();
        }

        public void ShowOpponentIconsAndLabels (List<Opponent> opponents)
        {
            Opponent[] ops = opponents.ToArray();
            if (opponents.Count >= 1)
            {
                buttonOpponent0.BackColor = ops[0].Color;
                labelOpponent0.Text = ops[0].Name;
                buttonOpponent0.Text = " ";
                buttonOpponent0.Show();
                labelOpponent0.Show();
            } if (opponents.Count >= 2)
            {
                buttonOpponent1.BackColor = ops[1].Color;
                labelOpponent1.Text = ops[1].Name;
                buttonOpponent1.Text = " ";
                buttonOpponent1.Show();
                labelOpponent1.Show();
            } if (opponents.Count >= 3)
            {
                buttonOpponent2.BackColor = ops[2].Color;
                labelOpponent2.Text = ops[2].Name;
                buttonOpponent2.Text = " ";
                buttonOpponent2.Show();
                labelOpponent2.Show();
            } if (opponents.Count >= 4)
            {
                buttonOpponent3.BackColor = ops[3].Color;
                labelOpponent3.Text = ops[3].Name;
                buttonOpponent3.Text = " ";
                buttonOpponent3.Show();
                labelOpponent3.Show();
            } if (opponents.Count >= 5)
            {
                buttonOpponent4.BackColor = ops[4].Color;
                labelOpponent4.Text = ops[4].Name;
                buttonOpponent4.Text = " ";
                buttonOpponent4.Show();
                labelOpponent4.Show();
            } if (opponents.Count >= 6)
            {
                buttonOpponent5.BackColor = ops[5].Color;
                labelOpponent5.Text = ops[5].Name;
                buttonOpponent5.Text = " ";
                buttonOpponent5.Show();
                labelOpponent5.Show();
            } if (opponents.Count >= 7)
            {
                buttonOpponent6.BackColor = ops[6].Color;
                labelOpponent6.Text = ops[6].Name;
                buttonOpponent6.Text = " ";
                buttonOpponent6.Show();
                labelOpponent6.Show();
            }
        }

        public void PlayerWins()
        {

        }

        public void OpponentLost (int i)
        {
            if (i == 0)
                buttonOpponent0.Text = "X";
            else if (i == 1)
                buttonOpponent1.Text = "X";
            else if (i == 2)
                buttonOpponent2.Text = "X";
            else if (i == 3)
                buttonOpponent3.Text = "X";
            else if (i == 4)
                buttonOpponent4.Text = "X";
            else if (i == 5)
                buttonOpponent5.Text = "X";
            else if (i == 6)
                buttonOpponent6.Text = "X";

        }

        //start new game
        private void buttonStartGame_Click(object sender, EventArgs e)
        {

            SetFieldAndHexSizes(comboBoxFieldSize.Text);
            GoToGame();

            //todo regex for unaccepted characters
            //else
        }

        public void SetFieldAndHexSizes (string input)
        {
            int i = Convert.ToInt32(input);
            switch(i)
            {
                case 8:
                    _hexSize = 49;
                    _yOffset = 80;
                    _xOffset = 65;
                    break;
                case 9:
                    _hexSize = 45;
                    _yOffset = 70;
                    _xOffset = 50;
                    break;
                case 10:
                    _hexSize = 42;
                    _yOffset = 70;
                    _xOffset = 38;
                    break;
                case 11:
                    _hexSize = 38;
                    _yOffset = 60;
                    _xOffset = 38;
                    break;
                case 12:
                    _hexSize = 36;
                    _yOffset = 60;
                    _xOffset = 30;
                    break;
                case 13:
                    _hexSize = 32;
                    _yOffset = 60;
                    _xOffset = 43;
                    break;
                case 14:
                    _hexSize = 30;
                    _yOffset = 60;
                    _xOffset = 35;
                    break;
                case 15:
                    _hexSize = 28;
                    _yOffset = 60;
                    _xOffset = 40;
                    break;
            }
        }

        public void Form_Paint(object sender, PaintEventArgs e)
        {
            //Draw the graphics/GUI

            foreach (Control c in this.Controls)
            {
                c.Refresh();
            }

            if (graphicsEngine != null)
            {
                graphicsEngine.Draw(e.Graphics);
                this.Invalidate();
            }

            //Force the next Paint()
            //this.Invalidate(); //gör att menyn blinkar

        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (graphicsEngine != null)
            {
                graphicsEngine = null;
            }

            if (_board != null)
            {
                _board = null;
            }
        }

        private void Form_MouseClick(object sender, MouseEventArgs e)
        {
            if (_currentGame != null)
                _currentGame.MouseClicked(sender, e, _xOffset, _yOffset);
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {

            try
            {
                Point mouseClick = new Point(e.X - _xOffset, e.Y - _yOffset);
                Hex clickedHex = _board.FindHexMouseClick(mouseClick);
                labelXY.Text = $"X: {clickedHex.xCoord} Y: {clickedHex.yCoord}";

            }
            catch (Exception ex)
            {

            }
        }

        private void textBoxPlayerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void SnakeBattle2_Load(object sender, EventArgs e)
        {

        
        }

        private void buttonQuitGame_Click(object sender, EventArgs e)
        {
            graphicsEngine = null;
            _board = null;
            _currentGame = null;
            GoToMainMenu();
        }

        public void ShowLoss()
        {
            buttonWin.Text = "YOU LOSE !";
            buttonWin.BackColor = Color.White;
            buttonWin.Show();
        }

        public void ShowWin()
        {
            buttonWin.Text = "YOU WIN !";
            buttonWin.BackColor = Color.White;
            buttonWin.Show();
            Thread.Sleep(5000);
            buttonWin.Hide();
        }

        private void showConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showConsoleToolStripMenuItem.Checked)
            {
                Program.HideConsole();
                showConsoleToolStripMenuItem.Checked = false;
            } else
            {
                Program.ShowConsole();
                showConsoleToolStripMenuItem.Checked = true;
            }
        }

        private void showCoordinatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showCoordinatesToolStripMenuItem.Checked)
            {
                labelXY.Hide();
                showCoordinatesToolStripMenuItem.Checked = false;
            } else
            {
                labelXY.Show();
                showCoordinatesToolStripMenuItem.Checked = true;
            }

        }


        //test
        private void buttonNewMP_Click(object sender, EventArgs e)
        {
            GoToConnectToServer();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (buttonConnect.ForeColor == Color.Red)
            {
                //todo connect to server

                if (true) //connection succeeded
                {
                    buttonUserName.Enabled = true;
                    textBoxUserName.Enabled = true;
                    textBoxConnect.Enabled = false;
                    buttonConnect.ForeColor = Color.Green;
                }
            } else if (buttonConnect.ForeColor == Color.Green)
            {
                //todo disconnect from server
                textBoxConnect.Clear(); 
                buttonConnect.ForeColor = Color.Red;
                
            }

        }

        private void buttonUserName_Click(object sender, EventArgs e)
        {
            if (buttonUserName.ForeColor == Color.Red)
            {
                //todo try to set user name
                if (true)
                {
                    buttonUserName.ForeColor = Color.Green;
                    buttonEnterServer.Enabled = true;
                    textBoxUserName.Enabled = false;
                }

            } else if (buttonUserName.ForeColor == Color.Green)
            {
                buttonUserName.ForeColor = Color.Red;
                buttonEnterServer.Enabled = false;
                textBoxUserName.Clear();
            }
        }
    }
}
