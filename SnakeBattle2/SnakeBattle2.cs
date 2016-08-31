using GameLogic;
using System;
using SnakeBattle2Server;
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
using System.Net;
using System.Text.RegularExpressions;
using MessagesLibrary;
using System.Diagnostics;

namespace SnakeBattle2
{
    public partial class SnakeBattle2 : Form
    {
        int _gamePort = 5000;
        public NetworkClient _nwc;
        Board _board;
        GraphicsEngine graphicsEngine;
        public Player _MPplayer;
        int _xOffset = 20;
        int _yOffset = 20;
        int _hexSize = 30;
        int _borderWidth = 2;
        public Color[] availableColors;
        GameRoom _currentLobby;
        MPGame _currentMPGame;
        SPGame _currentGame;
        public MPGame _currentMPgame;
        Thread connectionThread;
        Thread sendUserNameThread;
        Thread validateUserNameThread;
        Thread listenForMsg;
        Thread disableRefresh;
        ChatWindow cw;
        MessageQueue msgQ;

        public SnakeBattle2()
        {
            this.BackColor = Color.Black;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.DoubleBuffered = true;
            InitializeComponent();
            msgQ = new MessageQueue();
            CheckForIllegalCrossThreadCalls = false;
            _nwc = new NetworkClient(this, msgQ);
            GoToMainMenu();
            availableColors = new Color[8] { Color.Red, Color.Blue, Color.Yellow, Color.Green, Color.Gray, Color.HotPink, Color.DarkOrange, Color.Purple };
            for (int i = 2; i <= 8; i++)
                comboBoxPlayers.Items.Add(i);
            for (int i = 8; i <= 15; i++)
            {
                comboBoxFieldSize.Items.Add(i);
                comboBoxMPfieldSize.Items.Add(i);
            }
            foreach (var item in availableColors)
                comboBoxMyColor.Items.Add(item.Name);


            buttonWin.Location = new System.Drawing.Point(0, 280);
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
            labelConnectMessage.Hide();
            labelConnectMessage.Text = "";
            labelUserNameMessage.Hide();
            labelUserNameMessage.Text = "";
            textBoxUserName.Hide();
            buttonEnterServer.Hide();

            buttonConnectCancel.Hide();
            buttonStartGameCancel.Hide();

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

            labelMPavailableGames.Hide();
            listBoxMPavailableGames.Hide();
            buttonMPjoinGame.Hide();
            buttonMPcreateGame.Hide();
            buttonMPrefresh.Hide();
            buttonMPleaveServer.Hide();
            labelMPlobby.Hide();
            listBoxMPplayerLobby.Hide();
            buttonMPstartGame.Hide();
            buttonMPleaveLobby.Hide();
            buttonMPshowChat.Hide();
            labelMPfieldSize.Hide();
            comboBoxMPfieldSize.Hide();
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
            labelConnectMessage.Hide();
            labelConnectMessage.Text = "";
            labelUserNameMessage.Hide();
            labelUserNameMessage.Text = "";

            buttonConnectCancel.Hide();
            buttonStartGameCancel.Show();

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

            labelMPavailableGames.Hide();
            listBoxMPavailableGames.Hide();
            buttonMPjoinGame.Hide();
            buttonMPcreateGame.Hide();
            buttonMPrefresh.Hide();

            labelMPlobby.Hide();
            listBoxMPplayerLobby.Hide();
            buttonMPstartGame.Hide();
            buttonMPleaveLobby.Hide();
            buttonMPshowChat.Hide();
            labelMPfieldSize.Hide();
            comboBoxMPfieldSize.Hide();
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
            labelConnectMessage.Hide();
            labelConnectMessage.Text = "";
            labelUserNameMessage.Hide();
            labelUserNameMessage.Text = "";

            labelMPavailableGames.Hide();
            listBoxMPavailableGames.Hide();
            buttonMPjoinGame.Hide();
            buttonMPcreateGame.Hide();
            buttonMPrefresh.Hide();

            labelMPlobby.Hide();
            listBoxMPplayerLobby.Hide();
            buttonMPstartGame.Hide();
            buttonMPleaveLobby.Hide();
            buttonMPshowChat.Hide();
            labelMPfieldSize.Hide();
            comboBoxMPfieldSize.Hide();

            buttonConnectCancel.Hide();
            buttonStartGameCancel.Hide();

            Board board = new Board(Convert.ToInt32(comboBoxFieldSize.Text),
            Convert.ToInt32(comboBoxFieldSize.Text), _hexSize, HexOrientation.Pointy);

            board.BoardState.BackgroundColor = Color.Black; //background color of gameboard
            board.BoardState.GridPenWidth = _borderWidth;
            board.BoardState.ActiveHexBorderColor = Color.Red;
            board.BoardState.ActiveHexBorderWidth = _borderWidth;

            _currentGame = new SPGame(board, numberOfPlayers, player, availableColors, this);

            this._board = board;
            this.graphicsEngine = new GraphicsEngine(board, _xOffset, _yOffset, _currentGame);
        }

        public void GoToConnectToServer()
        {
            buttonConnect.Show();
            textBoxConnect.Show();
            labelConnect.Show();
            this.AcceptButton = buttonConnect;
            this.ActiveControl = textBoxConnect;
            labelConnectMessage.Show();
            labelConnectMessage.Text = "";
            labelUserNameMessage.Show();
            labelUserNameMessage.Text = "";

            buttonUserName.Show();
            buttonUserName.Enabled = false;
            labelUserName.Show();
            textBoxUserName.Show();
            textBoxUserName.Enabled = false;

            buttonEnterServer.Show();
            buttonEnterServer.Enabled = false;

            buttonNewMP.Hide();
            buttonNewSP.Hide();
            buttonConnectCancel.Show();
            buttonStartGameCancel.Hide();

        }

        public void GoToEnterServer()
        {
            _MPplayer = new Player(textBoxUserName.Text);
            Console.WriteLine($"Player {_MPplayer.Name} was created"); //create player locally
            msgQ._filterUserName = _MPplayer.Name;
            listenForMsg = new Thread(ReadCommandList);
            listenForMsg.Start();
            buttonConnect.Hide();
            textBoxConnect.Hide();
            labelConnect.Hide();

            labelConnectMessage.Hide();
            labelConnectMessage.Text = "";
            labelUserNameMessage.Hide();
            labelUserNameMessage.Text = "";

            buttonUserName.Hide();
            buttonUserName.Enabled = false;
            labelUserName.Hide();
            textBoxUserName.Hide();
            textBoxUserName.Enabled = false;
            buttonConnectCancel.Hide();

            buttonEnterServer.Hide();
            buttonEnterServer.Enabled = false;

            labelMPavailableGames.Show();
            listBoxMPavailableGames.Show();
            buttonMPjoinGame.Show();
            buttonMPcreateGame.Show();
            buttonMPrefresh.Show();
            buttonMPshowChat.Show();
            buttonMPleaveServer.Show();

        }

        public void GoToLobby (bool host)
        {
            buttonMPjoinGame.Enabled = false;
            buttonMPcreateGame.Enabled = false;
            labelMPlobby.Show();
            listBoxMPplayerLobby.Show();
            buttonMPleaveLobby.Show();
            if (host)
            {
                buttonMPstartGame.Show();
                labelMPfieldSize.Show();
                comboBoxMPfieldSize.Enabled = true;
                comboBoxMPfieldSize.SelectedIndex = 0;
                buttonMPstartGame.Enabled = true;
                comboBoxMPfieldSize.Show();
            }
        }

        public void GoToFindGame ()
        {
            labelMPlobby.Hide();
            listBoxMPplayerLobby.Hide();
            buttonMPstartGame.Enabled = false;
            buttonMPstartGame.Hide();
            buttonMPleaveLobby.Enabled = false;
            buttonMPleaveLobby.Hide();
            comboBoxMPfieldSize.Hide();
            labelMPfieldSize.Hide();
            buttonMPjoinGame.Enabled = true;
            buttonMPjoinGame.Show();
            buttonMPcreateGame.Enabled = true;
            buttonMPcreateGame.Show();
        }

        private void DisableRefreshButton ()
        {
            buttonMPrefresh.Enabled = false;
            Thread.Sleep(1400);
            buttonMPrefresh.Enabled = true;
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

        public void KillThread()
        {
            if (listenForMsg != null)
            {
                listenForMsg.Abort();
                listenForMsg = null;
            }
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

        public void ChatButtonGreenOnExit()
        {
            buttonMPshowChat.ForeColor = Color.Green;
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
            if (cw != null)
            {
                cw.KillTheThread();
            }
            KillThread();
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

        #region Connect to Server

        public void ConnectionSucceeded(bool ret)
        {
            if (ret)
            {
                labelConnectMessage.Text = "Connected to server.";
                buttonUserName.Enabled = true;
                textBoxUserName.Enabled = true;
                textBoxConnect.Enabled = false;
                textBoxConnect.ReadOnly = true;
                buttonConnect.ForeColor = Color.Green;
                this.ActiveControl = textBoxUserName;
            }
            else
                labelConnectMessage.Text = "Connection failed.";
        }

        private bool CheckUserName(string userName)
        {
            bool valid = false;
            if (!String.IsNullOrWhiteSpace(userName))
            {

                string pattern = @"^[a-zA-Z0-9åäöÅÄÖ]+$";
                Match result = Regex.Match(userName, pattern);
                if (userName.Length < 14 && userName.Length > 2 && userName != "<empty>" && result.Success)
                {
                    valid = true;
                }
                else
                {
                    labelUserNameMessage.Text = "User name invalid.";
                }
            }
            else
            {
                labelUserNameMessage.Text = "Please enter a user name.";
            }
            return valid;
        }

        private bool SendUserName(string name)
        {
            bool result = false;
            labelUserNameMessage.Text = "Sending user name to server.";
            try
            {
                UserNameMessage unm = new UserNameMessage(name);
                _nwc.Send(MessageHandler.Serialize(unm));
                //bool validated = false;
                validateUserNameThread = new Thread(() => ValidateUserName(name));
                validateUserNameThread.Start();
                //if (validated)
                //{
                //    labelUserNameMessage.Text = "User name set.";
                //}
                result = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }

            return result;

        }

        private bool ValidateUserName(string userName)
        {
            bool valid = false;
            Stopwatch myclock = new Stopwatch();
            myclock.Start();
            do
            {
                var msg = msgQ.ReadMessage();

                if (msg is UserNameMessage)
                {
                    UserNameMessage tmp = msg as UserNameMessage;
                    Console.WriteLine("time used: " + myclock.ElapsedMilliseconds);
                    bool result = tmp.UserNameConfirm;
                    if (result)
                    {
                        labelUserNameMessage.Text = "User name set.";
                        textBoxUserName.Enabled = false;
                        buttonUserName.Enabled = false;
                        buttonEnterServer.Enabled = true;
                    }
                    else
                    {
                        labelUserNameMessage.Text = "User name already taken";
                        buttonUserName.Enabled = true;
                    }


                    return result;
                }

                if (myclock.ElapsedMilliseconds > 10000)
                {
                    Console.WriteLine("User name validation timeout.");
                    buttonUserName.Enabled = true;
                    textBoxUserName.Enabled = true;
                    return false;
                }
            } while (!valid);

            return false;
        }

        #endregion

        private void buttonConnect_Click(object sender, EventArgs e) //connect to server
        {
            IPAddress ip;

            if (buttonConnect.ForeColor == Color.Red) //start connection attempt
            {
                if (IPAddress.TryParse(textBoxConnect.Text, out ip)) //check if input is a valid ip address
                {
                    connectionThread = new Thread(
                        () => _nwc.Connect(textBoxConnect.Text, _gamePort)
                    );

                    connectionThread.Start();
                } else
                    labelConnectMessage.Text = "Not a valid IP address.";
                

            } else if (buttonConnect.ForeColor == Color.Green)
            {
                labelConnectMessage.Text = "Disconnected.";
                _nwc.Send("quit");
                textBoxConnect.Clear();
                textBoxConnect.Enabled = true;
                textBoxConnect.ReadOnly = false;
                textBoxUserName.Clear();
                textBoxUserName.Enabled = false;
                buttonUserName.ForeColor = Color.Red;
                buttonConnect.ForeColor = Color.Red;
                buttonEnterServer.Enabled = false;
            }

        }

        private void buttonUserName_Click(object sender, EventArgs e)
        {
            if (buttonUserName.ForeColor == Color.Red)
            {
                buttonUserName.Enabled = false;
                string userName = textBoxUserName.Text;

                if (CheckUserName(textBoxUserName.Text))
                {
                    bool result = false;
                    sendUserNameThread = new Thread(() => result = SendUserName(userName));
                    sendUserNameThread.Start();
                    if (result)
                    {
                        labelUserNameMessage.Text = "User name sent.";
                    }
                } else
                {
                    buttonUserName.Enabled = true;
                }

            } else if (buttonUserName.ForeColor == Color.Green)
            {
                buttonUserName.ForeColor = Color.Red;
                buttonEnterServer.Enabled = false;
                textBoxUserName.Clear();
            }
            this.AcceptButton = buttonEnterServer;
            this.ActiveControl = null;
        }

        private void runServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SnakeBattle2Server.Program.Main(new string[] { "asdf" });
            //SnakeBattle2Server.Program sb2s = new SnakeBattle2Server.Program();
            //sb2s.Main(new string[] {"asdf", "asdf" });
        }

        private void textBoxConnect_TextChanged(object sender, EventArgs e)
        {
            labelConnectMessage.Text = "";
        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
            labelUserNameMessage.Text = "";
        }

        private void buttonConnectCancel_Click(object sender, EventArgs e)
        {
            _nwc.Send("quit");
            textBoxConnect.Clear();
            textBoxConnect.Enabled = true;
            textBoxConnect.ReadOnly = false;
            textBoxUserName.Clear();
            textBoxUserName.Enabled = false;
            buttonUserName.ForeColor = Color.Red;
            buttonConnect.ForeColor = Color.Red;
            buttonEnterServer.Enabled = false;
            GoToMainMenu();
        }

        private void buttonStartGameCancel_Click(object sender, EventArgs e)
        {
            GoToMainMenu();

        }

        private void buttonMPshowChat_Click(object sender, EventArgs e)
        {
            if (buttonMPshowChat.ForeColor == Color.Green)
            {
                cw = new ChatWindow(this);
                cw.Show();
                buttonMPshowChat.ForeColor = Color.Red;
            } else if (buttonMPshowChat.ForeColor == Color.Red)
            {
                cw.Hide();
                buttonMPshowChat.ForeColor = Color.Green;
            }
        }

        private void buttonMPstartGame_Click(object sender, EventArgs e)
        {

        }

        private void buttonMPleaveLobby_Click(object sender, EventArgs e)
        {
            if (_MPplayer.Name == _currentLobby.HostName) //destroy lobby, kick all players
                _nwc.Send(MessageHandler.Serialize(new NewLobbyMessage(_MPplayer.Name) { Create = false }));

        }

        private void buttonMPjoinGame_Click(object sender, EventArgs e)
        {
            if (listBoxMPavailableGames.SelectedIndex != -1)
            {
                GoToLobby(false); //go to lobby as player
            }
        }

        private void buttonMPcreateGame_Click(object sender, EventArgs e)
        {
            GoToLobby(true); //go to lobby as host
            _currentLobby = new GameRoom(_MPplayer.Name);
            NewLobbyMessage nlm = new NewLobbyMessage(_MPplayer.Name) { Create = true };
            try
            {
                Console.WriteLine($"Sending: {MessageHandler.Serialize(nlm)}");
                _nwc.Send(MessageHandler.Serialize(nlm));
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void buttonEnterServer_Click(object sender, EventArgs e)
        {
            GoToEnterServer();
        }

        private void buttonMPrefresh_Click(object sender, EventArgs e)
        {
            disableRefresh = new Thread(DisableRefreshButton);
            disableRefresh.Start();
            FindGameMessage fg = new FindGameMessage(_MPplayer.Name);
            Console.WriteLine("Sending request for game list");
            _nwc.Send(MessageHandler.Serialize(fg));
        }




        private void ReadCommandList ()
        {
            Console.WriteLine("Awaiting messages...");
            List<MessagesLibrary.Message> tmpRemove = new List<MessagesLibrary.Message>();

            do
            {
                MessagesLibrary.Message msg = msgQ.ReadMessage();

                //tmpRemove.Clear();
                //Thread.Sleep(100);
                //foreach (var item in _nwc._commandList)
                //{
                if (msg is FindGameMessage)
                {
                    listBoxMPavailableGames.Items.Clear();
                    Console.WriteLine("Received a list of available games");
                    var tmpMsg = msg as FindGameMessage;
                    foreach (var gm in tmpMsg.GamesAvailable)
                    {
                        if (gm.hasStarted)
                            listBoxMPavailableGames.Items.Add($"{gm.HostName} ({gm.PlayerList.Count}/8) [Game has started]");
                        else
                            listBoxMPavailableGames.Items.Add($"{gm.HostName} ({gm.PlayerList.Count}/8) [Available]");
                    }
                    //tmpRemove.Add(item);
                }
                else if (msg is ChatMessage)
                {
                    ChatMessage tmpmsg = msg as ChatMessage;
                    if (cw != null)
                        cw.receiveMessage(tmpmsg.Message);

                } else if (msg is PlayMessage)
                {

                }
                //}
                
                //foreach (var item in tmpRemove)
                //{
                //    _nwc._commandList.Remove(item);
                //}

            } while (true);
        }

        private void buttonMPleaveServer_Click(object sender, EventArgs e)
        {
            KillThread();
            GoToMainMenu();
        }
    }
}
