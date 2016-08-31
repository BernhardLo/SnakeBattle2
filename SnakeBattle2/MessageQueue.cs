using MessagesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeBattle2
{
    public class MessageQueue
    {
        readonly static object myLock = new object();
        private List<Message> msgQueue = new List<Message>();
        public string _filterUserName = "";
        public string _filterHostName = "";

        public void AddMessage(MessagesLibrary.Message msg)
        {
            lock (myLock)
            {
                Console.WriteLine("received a message to the queue");
                //var msg = MessageHandler.Deserialize(message);
                if (msg is UserNameMessage)
                {
                    Console.WriteLine("User name message received");
                    msgQueue.Add(msg);
                }
                else if (msg is FindGameMessage)
                {
                    Console.WriteLine("Find game message received");
                    msgQueue.Add(msg);

                }
                else if (msg is StartGameMessage)
                {
                    Console.WriteLine("Start game message received");
                    Thread.Sleep(500);
                    if (msg.UserName == _filterHostName)
                        msgQueue.Add(msg);

                }
                else if (msg is PlayMessage)
                {
                    Console.WriteLine("Play message received");
                    PlayMessage tmp = msg as PlayMessage;
                    if (tmp.HostName == _filterHostName)
                        msgQueue.Add(msg);
                }
                else if (msg is JoinGameMessage)
                {
                    Console.WriteLine("Join game message received");
                    if (msg.UserName == _filterUserName)
                        msgQueue.Add(msg);
                }
                else if (msg is ChatMessage)
                {
                    Console.WriteLine("Chat message received");
                    msgQueue.Add(msg);
                } else if (msg is KickMessage)
                {
                    if (msg.UserName == _filterUserName)
                    {
                        Console.WriteLine("Kick message received");
                        msgQueue.Add(msg);
                    }
                }
                else if (msg is ErrorMessage)
                {
                    Console.WriteLine("Error message received");
                    msgQueue.Add(msg);
                }
                Monitor.PulseAll(myLock);
            }
        }

        public Message ReadMessage()
        {
            Message tmpMsg = null;

            lock (myLock)
            {
                if (msgQueue.Count > 0)
                {
                    tmpMsg = msgQueue.First();

                    Console.Write("Read message from Q: " + MessageHandler.Serialize(tmpMsg));

                    msgQueue.RemoveAt(0);
                }
                else
                {
                    Console.WriteLine("List is empty, waiting for message...");
                    Monitor.Wait(myLock);
                }
            }

            return tmpMsg;
        }
    }
}
