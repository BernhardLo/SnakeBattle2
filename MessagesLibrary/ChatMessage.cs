using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesLibrary
{
    public class ChatMessage : Message
    {
        public ChatMessage(string userName, string message) : base (userName)
        {
            this.Message = message;
        }
        public string Message { get; set; }
    }
}
