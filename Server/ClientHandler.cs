using GameLogic;
using MessagesLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SnakeBattle2Server
{
    public class ClientHandler
    {
        public string UserName { get; set; }
        public TcpClient tcpclient;
        private Server myServer;
        private List<Message> errorList = new List<Message>();
        public ClientHandler(TcpClient c, Server server)
        {
            tcpclient = c;
            this.myServer = server;
            this.UserName = "<empty>";
        }

        public void Run()
        {
            try
            {
                string message = "";
                while (!message.Equals("quit"))
                {
                    NetworkStream n = tcpclient.GetStream();
                    message = new BinaryReader(n).ReadString();
                    Console.WriteLine(message);
                    var msg = MessageHandler.Deserialize(message);

                    if (msg is UserNameMessage)
                    {
                        UserNameMessage response = msg as UserNameMessage;
                        response.UserNameConfirm = myServer.CheckUserName(msg.UserName);
                        this.UserName = response.UserName;
                        myServer.PrivateSend(tcpclient, MessageHandler.Serialize(response));
                    }
                    else if (msg is PlayMessage)
                    {
                        PlayMessage response = msg as PlayMessage;
                        response = myServer.GetNextUser(response);
                        response.TurnCount++;
                        myServer.Broadcast(MessageHandler.Serialize(response));
                    }
                    //else if (msg is NewGameMessage)
                    //{
                    //    NewGameMessage tmp = msg as NewGameMessage;
                    //    GameRoom room = new GameRoom() { HostName = tmp.UserName };
                    //    Player tmpPlayer = new Player(tmp.UserName);
                    //    room.PlayerList.Add(tmpPlayer);
                    //    myServer._games.Add(room);
                    //}
                    else if (msg is NewLobbyMessage)
                    {
                        NewLobbyMessage tmp = msg as NewLobbyMessage;
                        if (tmp.Create) //todo create lobby
                        {
                            GameRoom room = new GameRoom(tmp.UserName);
                            room.PlayerList.Add(new Player(tmp.UserName));
                            myServer._games.Add(room);
                        
                        } else //todo remove lobby
                        {
                            //todo kick all users
                            myServer._games.RemoveAll(x => x.HostName == tmp.UserName);
                        }
                        foreach (var item in myServer._games)
                        {
                            Console.WriteLine("Game name: " + item.HostName);
                        }
                    }
                    else if (msg is FindGameMessage)
                    {
                        FindGameMessage tmp = msg as FindGameMessage;
                        foreach (var item in myServer._games)
                        {
                            tmp.GamesAvailable.Add(item);
                        }
                        myServer.PrivateSend(tcpclient, MessageHandler.Serialize(tmp));

                    }
                    else if (msg is ChatMessage)
                    {
                        myServer.Broadcast(MessageHandler.Serialize(msg));
                    }
                    else if (msg is JoinGameMessage)
                    {
                        JoinGameMessage tmp = msg as JoinGameMessage;
                        bool gameOn = false;
                        foreach (var item in myServer._games)
                        {
                            if (tmp.HostName == item.HostName)
                                if (true/*item.PlayerList.Count == item.NumberOfPlayers - 1*/) //todo check for full game
                                {
                                    Player tmpPlayer = new Player(tmp.UserName);
                                    item.PlayerList.Add(tmpPlayer);
                                    tmp.Confirmed = true;
                                    gameOn = true;
                                }
                                else if (true/*item.PlayerList.Count < item.NumberOfPlayers*/) //todo
                                {
                                    Player tmpPlayer = new Player(tmp.UserName);
                                    item.PlayerList.Add(tmpPlayer);
                                    tmp.Confirmed = true;
                                }
                        }
                        myServer.PrivateSend(tcpclient, MessageHandler.Serialize(tmp));
                        if (gameOn)
                        {
                            myServer.SendStartGameMessage(tmp.HostName);
                        }
                    }
                    else if (msg is ErrorMessage)
                    {
                        errorList.Add(msg);
                        if (errorList.Count > 10)
                        {
                            myServer.DisconnectClient(this);
                            tcpclient.Close();
                        }
                    }

                }

                myServer.DisconnectClient(this);
                tcpclient.Close();
            }
            catch (IOException)
            {
                Console.WriteLine(this.UserName + " Remote client disconnected.");
                myServer.DisconnectClient(this);
                tcpclient.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
