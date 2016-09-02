using GameLogic;
using MessagesLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeBattle2Server
{
    public class ClientHandler
    {
        public string UserName { get; set; }
        public TcpClient tcpclient;
        private Server myServer;
        private List<Message> errorList = new List<Message>();
        ServerQueue serverQ;
        Thread queueReader;

        public ClientHandler(TcpClient c, Server server)
        {
            tcpclient = c;
            this.myServer = server;
            this.UserName = "<empty>";
            serverQ = new ServerQueue();
        }

        public void AddMessage(Message messageToQueue)
        {
            serverQ.AddMessage(MessageHandler.Serialize(messageToQueue));
        }

        public void Run() //server receives messages
        {
            queueReader = new Thread(ReadMessage);
            queueReader.Start();
            try
            {
                string message = "";
                while (!message.Equals("quit"))
                {
                    NetworkStream n = tcpclient.GetStream();
                    message = new BinaryReader(n).ReadString();
                    Console.WriteLine("received: " + message);
                    serverQ.AddMessage(message);

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

        public void SendMessage(string message)
        {
            NetworkStream n = tcpclient.GetStream();
            BinaryWriter w = new BinaryWriter(n);
            w.Write(message);
            w.Flush();
        }

        private void ReadMessage()
        {
            while (true)
            {

                Message msg = serverQ.ReadMessage();

                if (msg is UserNameMessage)
                {
                    Console.WriteLine("received username message");
                    UserNameMessage response = msg as UserNameMessage;
                    response.UserNameConfirm = myServer.CheckUserName(msg.UserName);
                    this.UserName = response.UserName;
                    Console.WriteLine("sending username message");
                    SendMessage(MessageHandler.Serialize(response));
                }
                else if (msg is PlayMessage) //todo handle player turn
                {
                    PlayMessage tpm = msg as PlayMessage;

                    if (tpm.Sender == "client")
                    {

                        myServer.Broadcast(MessageHandler.Serialize(tpm));
                    } else
                    {
                        SendMessage(MessageHandler.Serialize(tpm));
                    }



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
                else if (msg is StartGameMessage)
                {
                    StartGameMessage sgm = msg as StartGameMessage;
                    if (sgm.Sender == "client")
                    {
                        foreach (var item in myServer._games)
                        {
                            if (item.HostName == sgm.UserName)
                            {
                                item.hasStarted = true;
                            }
                        }
                        myServer.Broadcast(MessageHandler.Serialize(sgm));

                    }
                    else
                    {
                        SendMessage(MessageHandler.Serialize(sgm));
                    }
                }
                else if (msg is NewLobbyMessage)
                {
                    NewLobbyMessage tmp = msg as NewLobbyMessage;
                    if (tmp.Sender == "client")
                    {
                        if (tmp.Create)
                        {
                            GameRoom room = new GameRoom(tmp.UserName);
                            room.PlayerList.Add(new Player(tmp.UserName));
                            myServer._games.Add(room);

                        }
                        else //todo remove lobby
                        {
                            //todo kick all users
                            foreach (var item in myServer._games)
                            {
                                if (item.HostName == tmp.UserName)
                                {
                                    foreach (Player p in item.PlayerList)
                                    {
                                        KickMessage km = new KickMessage(p.Name);
                                        km.Sender = "client";
                                        myServer.Broadcast(MessageHandler.Serialize(km));
                                        //todo send kickmessage to all users
                                    }
                                    item.PlayerList.Clear();
                                }
                            }
                            myServer._games.RemoveAll(x => x.HostName == tmp.UserName);
                        }
                        foreach (var item in myServer._games)
                        {
                            Console.WriteLine("active game: " + item.HostName);
                        }

                    }
                    else
                    {
                    }
                }
                else if (msg is KickMessage)
                {
                    KickMessage tmp = msg as KickMessage;
                    Player tmpP = new Player("<empty>");

                    if (msg.Sender == "client")
                    {
                        foreach (var item in myServer._games)
                        {
                            foreach (var player in item.PlayerList)
                            {
                                if (player.Name == tmp.UserName) //found player wanting to leave
                                {
                                    tmpP = player;
                                }
                            }
                            if (tmpP.Name != "<empty>")
                            {
                                item.PlayerList.Remove(tmpP);
                                KickMessage km = new KickMessage(tmpP.Name);
                                km.Sender = "server";
                                SendMessage(MessageHandler.Serialize(km));
                                //myServer.PrivateSend(tcpclient, MessageHandler.Serialize(km));
                                foreach (Player p in item.PlayerList) //todo does this work? broadcasting update after player leaves
                                {
                                    JoinGameMessage jj = new JoinGameMessage(p.Name) { HostName = item.HostName, PlayerListLobby = item.PlayerList, Confirmed = true };
                                    myServer.Broadcast(MessageHandler.Serialize(jj));
                                }
                            }
                        }
                    }
                    else
                    {
                        SendMessage(MessageHandler.Serialize(tmp));
                    }
                }
                else if (msg is FindGameMessage)
                {
                    FindGameMessage tmp = msg as FindGameMessage;
                    foreach (var item in myServer._games)
                    {
                        tmp.GamesAvailable.Add(item);
                    }
                    //myServer.PrivateSend(tcpclient, MessageHandler.Serialize(tmp));
                    SendMessage(MessageHandler.Serialize(tmp));

                }
                else if (msg is ChatMessage)
                {
                    if (msg.Sender == "client")
                    {
                        myServer.Broadcast(MessageHandler.Serialize(msg));

                    }
                    else
                    {
                        SendMessage(MessageHandler.Serialize(msg));
                    }
                }
                else if (msg is JoinGameMessage)
                {
                    JoinGameMessage tmp = msg as JoinGameMessage;

                    if (msg.Sender == "client")
                    {
                        foreach (var item in myServer._games)
                        {
                            if (tmp.HostName == item.HostName && item.PlayerList.Count < 8 && !item.hasStarted)
                            {
                                Player tmpPlayer = new Player(tmp.UserName);
                                item.PlayerList.Add(tmpPlayer);
                                foreach (Player p in item.PlayerList) //broadcast update to all players
                                {
                                    JoinGameMessage jj = new JoinGameMessage(p.Name) { HostName = item.HostName, PlayerListLobby = item.PlayerList, Confirmed = true };
                                    myServer.Broadcast(MessageHandler.Serialize(jj));
                                }
                                tmp.PlayerListLobby = item.PlayerList;
                                tmp.Confirmed = true;
                            }
                            else
                            {
                                tmp.Confirmed = false;
                            }
                        }

                        tmp.Sender = "server";
                        SendMessage(MessageHandler.Serialize(tmp));
                        //myServer.PrivateSend(tcpclient, MessageHandler.Serialize(tmp));
                    }
                    else
                    {
                        SendMessage(MessageHandler.Serialize(tmp));

                    }

                }
                else if (msg is ErrorMessage)
                {
                    //errorList.Add(msg);
                    //if (errorList.Count > 10)
                    //{
                    //    myServer.DisconnectClient(this);
                    //    tcpclient.Close();
                    //}
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

        }
    }
}
