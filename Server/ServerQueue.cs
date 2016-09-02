using MessagesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeBattle2Server
{
    public class ServerQueue
    {
        readonly static object myLock = new object();
        private List<string> msgQueue = new List<string>();

        public void AddMessage(string msg)
        {
            lock (myLock)
            {
                msgQueue.Add(msg);
                Console.WriteLine("pulse lock on Thread " + Thread.CurrentThread.ManagedThreadId);
                Monitor.PulseAll(myLock);
            }
        }

        public Message ReadMessage()
        {

            Message tmpMsg = new ErrorMessage("<empty>");


            lock (myLock)
            {
                if (msgQueue.Count > 0)
                {
                    tmpMsg = MessageHandler.Deserialize(msgQueue.First());

                    Console.Write("Read message from Q: " + MessageHandler.Serialize(tmpMsg));

                    msgQueue.RemoveAt(0);
                }
                else
                {
                    Console.WriteLine("List is empty, waiting for message...");
                    Console.WriteLine("Waiting for lock on thread: " + Thread.CurrentThread.ManagedThreadId);
                    Monitor.Wait(myLock);

                    Console.WriteLine("Pulse recieved");
                }
            }

            return tmpMsg;
        }
    }
}