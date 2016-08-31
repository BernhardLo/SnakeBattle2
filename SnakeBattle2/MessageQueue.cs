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

        public void AddMessage(MessagesLibrary.Message message)
        {
            lock (myLock)
            {
                msgQueue.Add(message);
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

                    Console.Write("Read message: " + MessageHandler.Serialize(tmpMsg));

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
