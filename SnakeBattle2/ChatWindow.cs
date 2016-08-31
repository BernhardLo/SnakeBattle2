using MessagesLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeBattle2
{
    public partial class ChatWindow : Form
    {
        SnakeBattle2 _windowRef;
        Thread listenForMsg;
        //MessageQueue cmsgQ;
        public ChatWindow(SnakeBattle2 winRef)
        {
            _windowRef = winRef;
            int top = _windowRef.Top;
            int right = _windowRef.Right;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(right, top);
            this.BackColor = Color.Black;
            InitializeComponent();
            textBoxMainChat.ReadOnly = true;
            textBoxWrite.MaxLength = 80;
            textBoxMainChat.ScrollBars = ScrollBars.Vertical;
            this.AcceptButton = buttonSend;
            this.ActiveControl = textBoxWrite;
            //listenForMsg = new Thread(WaitForChatMessage);
            //listenForMsg.Start();
        }

        public void ChatWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            KillTheThread();
            _windowRef.ChatButtonGreenOnExit();
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        public void KillTheThread()
        {
            if (listenForMsg != null)
            {
                listenForMsg.Abort();
                listenForMsg = null;
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxWrite.Text))
            {
                DateTime dt = DateTime.Now;
                string timestamp = dt.ToString("HH:mm:ss");
                string name = _windowRef._MPplayer.Name;
                string msg = $"{timestamp} {name}: {textBoxWrite.Text}";
                ChatMessage cm = new ChatMessage(_windowRef._MPplayer.Name, msg);
                try
                {
                    Console.WriteLine($"Sending {MessageHandler.Serialize(cm)}");
                    _windowRef._nwc.Send(MessageHandler.Serialize(cm));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //textBoxMainChat.AppendText(msg + "\n");
                textBoxWrite.Clear();
            }
        }

        public void receiveMessage(string msg)
        {
            textBoxMainChat.AppendText(msg + "\n");
        }

        //private void WaitForChatMessage()
        //{
        //    Console.WriteLine("Awaiting chat messages...");
        //    do
        //    {
        //        MessagesLibrary.Message msg = cmsgQ.ReadMessage();

        //        //Thread.Sleep(200);
        //        //List<ChatMessage> tmpRemove = new List<ChatMessage>();
        //        //foreach (var item in _windowRef._nwc._commandList)
        //        //{
        //            if (msg is ChatMessage)
        //            {
        //                ChatMessage cm = msg as ChatMessage;
        //                string print = cm.Message;
        //                //if (cm.UserName != _windowRef._MPplayer.Name)
        //                receiveMessage(print);
        //                //tmpRemove.Add(item as ChatMessage);

        //            }
        //        //}

        //        //foreach (var item in tmpRemove)
        //        //{
        //        //    _windowRef._nwc._commandList.Remove(item);
        //        //}

        //    } while (true);
        //}
    }
}
