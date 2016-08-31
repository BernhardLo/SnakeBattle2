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
                    Console.WriteLine("received: " +message);
                    var msg = MessageHandler.Deserialize(message);

                    if (msg is UserNameMessage)
                    {
                        UserNameMessage response = msg as UserNameMessage;
                        response.UserNameConfirm = myServer.CheckUserName(msg.UserName);
                        this.UserName = response.UserName;
                        myServer.PrivateSend(tcpclient, MessageHandler.Serialize(response));
                    }
                    else if (msg is PlayMessage) //todo handle player turn
                    {
                        //PlayMessage response = msg as PlayMessage;
                        //response = myServer.GetNextUser(response);
                        //response.TurnCount++;
                        //myServer.Broadcast(MessageHandler.Serialize(response));
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
                        if (tmp.Create)
                        {
                            GameRoom room = new GameRoom(tmp.UserName);
                            room.PlayerList.Add(new Player(tmp.UserName));
                            myServer._games.Add(room);

                        }
                        else //todo remove lobby
                        {
                            //todo kick all users
                            foreach(var item in myServer._games)
                            {
                                if (item.HostName == tmp.UserName)
                                {
                                    foreach (Player p in item.PlayerList)
                                    {
                                        KickMessage km = new KickMessage(p.Name);
                                        myServer.Broadcast(MessageHandler.Serialize(km));
                                        //todo send kickmessage to all users
                                    }
                                }
                            }
                            myServer._games.RemoveAll(x => x.HostName == tmp.UserName);
                        }
                        foreach (var item in myServer._games)
                        {
                            Console.WriteLine("active game: " + item.HostName);
                        }
                    }
                    else if (msg is KickMessage)
                    {
                        KickMessage tmp = msg as KickMessage;
                        Player tmpP = null;

                        foreach (var item in myServer._games)
                        {
                            foreach (var player in item.PlayerList)
                            {
                                if (player.Name == tmp.UserName)
                                {
                                    tmpP = player;
                                }
                            }
                            if (tmpP != null)
                            {
                                item.PlayerList.Remove(tmpP);
                                KickMessage km = new KickMessage(tmpP.Name);
                                myServer.PrivateSend(tcpclient, MessageHandler.Serialize(km));
                            }
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
                        //bool gameOn = false;
                        foreach (var item in myServer._games)
                        {
                            if (tmp.HostName == item.HostName && item.PlayerList.Count < 8 && !item.hasStarted)
                            {
                                Player tmpPlayer = new Player(tmp.UserName);
                                item.PlayerList.Add(tmpPlayer);
                                tmp.Confirmed = true;
                                //gameOn = true;
                            } else
                            {
                                tmp.Confirmed = false;
                            }
                        }

                        myServer.PrivateSend(tcpclient, MessageHandler.Serialize(tmp));
                        //if (gameOn)
                        //{
                        //    myServer.SendStartGameMessage(tmp.HostName);
                        //}
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
