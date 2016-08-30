using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeBattle2
{
    public partial class ChatWindow : Form
    {
        SnakeBattle2 _windowRef;
        public ChatWindow(SnakeBattle2 winRef)
        {
            _windowRef = winRef;

            int top = _windowRef.Top;
            int right = _windowRef.Right;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(right, top);
            this.BackColor = Color.Black;
            InitializeComponent();
            textBoxMainChat.Enabled = false;
            this.AcceptButton = buttonSend;
        }

        public void ChatWindow_FormClosing (object sender, FormClosingEventArgs e)
        {
            _windowRef.ChatButtonGreenOnExit();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {

            DateTime dt = DateTime.Now;

            string timestamp = dt.ToString("HH:mm:ss"); // 07:00 // 24 hour clock // hour is always 2 digits
            //dt.ToString("hh:mm tt"); // 07:00 AM // 12 hour clock // hour is always 2 digits
            //dt.ToString("H:mm"); // 7:00 // 24 hour clock
            //dt.ToString("h:mm tt"); // 7:00 AM // 12 hour clock

            string msg = timestamp + " " + textBoxWrite.Text;
            textBoxMainChat.AppendText(msg + "\n");
            textBoxWrite.Clear();
        }
    }
}
